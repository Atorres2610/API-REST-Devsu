using Devsu.API.Middlewares;
using Devsu.Core;
using Devsu.Core.Models;
using Devsu.Infrastructure;
using Devsu.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var corsPolitica = "DevsuApiCorsPolicy";

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(j => j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt => opt.UseInlineDefinitionsForEnums());
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddCore();
builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.InvalidModelStateResponseFactory = (errorContext) =>
    {
        IEnumerable<string> errores = errorContext.ModelState.Where(m => !m.Key.Equals("request")).SelectMany(m => m.Value?.Errors.Select(e => e.ErrorMessage) ?? new List<string>());

        string mensaje = errorContext.ModelState.TryGetValue("request", out _) ? "El cuerpo de la solictud no tiene el formato correcto." : "Se presentaron uno o más errores de validación.";

        return new BadRequestObjectResult(new ResultData(HttpStatusCode.BadRequest, mensaje, errores));
    };
});
builder.Services.AddCors(opt => opt.AddPolicy(corsPolitica, p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

//Creacion del esquema de tablas en SQLite para pruebas de integración 
if (!(app.Environment.IsDevelopment() || app.Environment.IsProduction()))
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DevsuContext>();
    await context.Database.EnsureCreatedAsync();
}

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

public partial class Program { }