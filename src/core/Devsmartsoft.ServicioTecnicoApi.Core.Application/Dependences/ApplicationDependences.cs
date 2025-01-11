using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Implementation;
using Devsmartsoft.ServicioTecnicoApi.Core.Application.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Application.Dependences
{
    public static class ApplicationDependences
    {
        public static void InjectApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IClienteBusiness, ClienteBusiness>();
            services.AddTransient<IConfiguracionBusiness, ConfiguracionBusiness>();
            services.AddTransient<IElementoBusiness, ElementoBusiness>();
            services.AddTransient<IEstadoBusiness, EstadoBusiness>();
            services.AddTransient<IEvidenciaBusiness, EvidenciaBusiness>();
            services.AddTransient<IFormaPagoBusiness, FormaPagoBusiness>();
            services.AddTransient<IGastoBusiness, GastoBusiness>();
            services.AddTransient<IMovimientoRepuestoBusiness, MovimientoRepuestoBusiness>();
            services.AddTransient<INovedadBusiness, NovedadBusiness>();
            services.AddTransient<IRepuestoBusiness, RepuestoBusiness>();
            services.AddTransient<IServicioBusiness, ServicioBusiness>();
            services.AddTransient<IServicioTrazabilidadBusiness, ServicioTrazabilidadBusiness>();
            services.AddTransient<ITecnicoBusiness, TecnicoBusiness>();
            services.AddTransient<ITipoGastoBusiness, TipoGastoBusiness>();
            services.AddTransient<IUbicacionBusiness, UbicacionBusiness>();
            services.AddTransient<IVentaBusiness, VentaBusiness>();
            services.AddTransient<IVentaDetalleBusiness, VentaDetalleBusiness>();         
            services.AddTransient<IChatBusiness, ChatBusiness>();

        }
    }
}
