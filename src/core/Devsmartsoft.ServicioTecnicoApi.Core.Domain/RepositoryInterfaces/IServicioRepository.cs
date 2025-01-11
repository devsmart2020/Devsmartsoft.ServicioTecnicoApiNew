using Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces
{
    public interface IServicioRepository : IRepository<Servicio>
    {
        Task<IEnumerable<ServicioReporte>> ListarPorFiltro(SearchOrderFilter filter);
    }
}
