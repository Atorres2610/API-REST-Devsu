using AutoMapper;
using Devsu.Core.Features.Movimiento.Commands.ActualizarMovimiento;
using Devsu.Core.Features.Movimiento.Commands.GuardarMovimiento;
using Devsu.Core.Features.Movimiento.Queries.ListarMovimiento;
using Devsu.Core.Features.Movimiento.Queries.ObtenerMovimiento;

namespace Devsu.Core.MappingProfiles
{
    public class MovimientoMappingProfile : Profile
    {
        public MovimientoMappingProfile()
        {
            _ = CreateMap<Entities.Movimiento, ListarMovimientoResponse.MovimientoResponse>();
            _ = CreateMap<List<Entities.Movimiento>, ListarMovimientoResponse>()
                .ForMember(dest => dest.Movimientos, opt => opt.MapFrom(src => src));

            _ = CreateMap<Entities.Movimiento, ObtenerMovimientoResponse.MovimientoResponse>();
            _ = CreateMap<Entities.Movimiento, ObtenerMovimientoResponse>()
                .ForMember(dest => dest.Movimiento, opt => opt.MapFrom(src => src));

            _ = CreateMap<GuardarMovimientoCommand, Entities.Movimiento>();
            _ = CreateMap<ActualizarMovimientoCommand, Entities.Movimiento>();
        }
    }
}
