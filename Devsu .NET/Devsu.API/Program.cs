using Devsu.API.Middlewares;
using Devsu.Core;
using Devsu.Core.Models;
using Devsu.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var corsPolitica = "DevsuApiCorsPolicy";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<JsonOptions>(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => opt.UseInlineDefinitionsForEnums());
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddCore();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    var response = opt.ClientErrorMapping;
    opt.InvalidModelStateResponseFactory = (errorContext) =>
    {
        IEnumerable<string> errores = errorContext.ModelState.Where(m => !m.Key.Equals("request")).SelectMany(m => m.Value.Errors.Select(e => e.ErrorMessage));

        string mensaje = errorContext.ModelState.TryGetValue("request", out _) ? "El cuerpo de la solictud no tiene el formato correcto" : "Se presentaron uno o más errores de validación.";

        return new BadRequestObjectResult(new ResultData(HttpStatusCode.BadRequest, mensaje, errores));
    };
});
builder.Services.AddCors(opt => opt.AddPolicy(corsPolitica, p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(corsPolitica);
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
