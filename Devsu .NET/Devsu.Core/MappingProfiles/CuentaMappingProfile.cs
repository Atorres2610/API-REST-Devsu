using AutoMapper;
using Devsu.Core.Features.Cuenta.Commands.ActualizarCuenta;
using Devsu.Core.Features.Cuenta.Commands.GuardarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ListarCuenta;
using Devsu.Core.Features.Cuenta.Queries.ObtenerCuenta;

namespace Devsu.Core.MappingProfiles
{
    public class CuentaMappingProfile : Profile
    {
        public CuentaMappingProfile() : base(nameof(CuentaMappingProfile))
        {
            _ = CreateMap<ActualizarCuentaCommand, Entities.Cuenta>();
            _ = CreateMap<GuardarCuentaCommand, Entities.Cuenta>();

            _ = CreateMap<Entities.Cuenta, ListarCuentaResponse.CuentaResponse>();
            _ = CreateMap<List<Entities.Cuenta>, ListarCuentaResponse>()
                .ForMember(dest => dest.Cuentas, opt => opt.MapFrom(src => src));

            _ = CreateMap<Entities.Cuenta, ObtenerCuentaResponse.CuentaResponse>();
            _ = CreateMap<Entities.Cuenta, ObtenerCuentaResponse>()
                .ForMember(dest => dest.Cuenta, opt => opt.MapFrom(src => src));
        }
    }
}
