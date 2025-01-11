using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Firebase;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.OpenAI;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Resources;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Dependences
{
    public static class PersistenceDependences
    {
        public static void InjectPersistence(this IServiceCollection services)
        {

            services.AddDbContext<DbServiciotecnicoContext>(options =>
                                                            options.UseSqlServer(ResourcesPersistence.Db_localConn));
            services.AddSingleton<IFirebaseRepository, FirebaseRepository>();
            services.AddSingleton<IOrderUpdateService, OrderUpdateService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IConfiguracionRepository, ConfiguracionRepository>();
            services.AddScoped<IElementoRepository, ElementoRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEvidenciaRepository, EvidenciaRepository>();
            services.AddScoped<IFormaPagoRepository, FormaPagoRepository>();
            services.AddScoped<IGastoRepository, GastoRepository>();
            services.AddScoped<IMovimientoRepuestoRepository, MovimientoRepuestoRepository>();
            services.AddScoped<INovedadRepository, NovedadRepository>();
            services.AddScoped<IRepuestoRepository, RepuestoRepository>();
            services.AddScoped<IServicioRepository, ServicioRepository>();
            services.AddScoped<IServicioTrazabilidadRepository, ServicioTrazabilidadRepository>();
            services.AddScoped<ITecnicoRepository, TecnicoRepository>();
            services.AddScoped<ITipoGastoRepository, TipoGastoRepository>();
            services.AddScoped<IUbicacionRepository, UbicacionRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IVentaDetalleRepository, VentaDetalleRepository>();
            services.AddScoped<IClientGpt, ClientGpt>();
        }
    }
}
