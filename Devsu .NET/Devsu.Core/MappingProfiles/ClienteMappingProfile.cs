using AutoMapper;
using Devsu.Core.Features.Cliente.Commands.ActualizarCliente;
using Devsu.Core.Features.Cliente.Commands.GuardarCliente;
using Devsu.Core.Features.Cliente.Queries.ListarCliente;
using Devsu.Core.Features.Cliente.Queries.ObtenerCliente;

namespace Devsu.Core.MappingProfiles
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            _ = CreateMap<Entities.Cliente, ObtenerClienteResponse.ClienteResponse>()
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(src => src.IdPersonaNavigation.Nombres))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.IdPersonaNavigation.Telefono))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.IdPersonaNavigation.Direccion))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.IdPersonaNavigation.Genero))
                .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.IdPersonaNavigation.Identificacion))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.IdPersonaNavigation.Telefono))
                .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => src.IdPersonaNavigation.Edad));
            _ = CreateMap<Entities.Cliente, ObtenerClienteResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src));

            _ = CreateMap<Entities.Cliente, ListarClienteResponse.ClienteResponse>()
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.IdPersonaNavigation.Nombres));
            _ = CreateMap<List<Entities.Cliente>, ListarClienteResponse>()
                .ForMember(dest => dest.Clientes, opt => opt.MapFrom(src => src));

            _ = CreateMap<GuardarClienteCommand, Entities.Cliente>();
            _ = CreateMap<GuardarClienteCommand, Entities.Persona>();
            _ = CreateMap<ActualizarClienteCommand, Entities.Cliente>();
            _ = CreateMap<ActualizarClienteCommand, Entities.Persona>();
        }
    }
}
