using AutoMapper;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Common;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Response;
using Devsmartsoft.ServicioTecnicoApi.Core.Dtos.Transport;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Configuracion, ConfiguracionDto>().ReverseMap();
            CreateMap<Elemento, ElementoDto>().ReverseMap();
            CreateMap<Estado, EstadoDto>().ReverseMap();
            CreateMap<Evidencia, EvidenciaDto>().ReverseMap();
            CreateMap<FormaPago, FormaPagoDto>().ReverseMap();
            CreateMap<Gasto, GastoDto>().ReverseMap();
            CreateMap<MovimientoRepuesto, MovimientoRepuestoDto>().ReverseMap();
            CreateMap<Novedad, NovedadDto>().ReverseMap();
            CreateMap<Repuesto, RepuestoDto>().ReverseMap();
            CreateMap<Servicio, ServicioDto>().ReverseMap();
            CreateMap<ServicioTrazabilidad, ServicioTrazabilidadDto>().ReverseMap();
            CreateMap<Tecnico, TecnicoDto>().ReverseMap();
            CreateMap<TipoGasto, TipoGastoDto>().ReverseMap();
            CreateMap<Ubicacion, UbicacionDto>().ReverseMap();
            CreateMap<Venta, VentaDto>().ReverseMap();
            CreateMap<VentaDetalle, VentaDetalleDto>().ReverseMap();
            CreateMap<SearchOrderFilter, SearchOrderFilterDto>().ReverseMap();
            CreateMap<ServicioReporte, ServicioReporteDto>().ReverseMap();
        }
    }
}
