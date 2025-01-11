using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories.Base;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories
{
    public sealed class ServicioTrazabilidadRepository : BaseRepository<ServicioTrazabilidad>, IServicioTrazabilidadRepository
    {
        #region Fields

        #endregion

        #region Ctor
        public ServicioTrazabilidadRepository(DbServiciotecnicoContext context) : base(context)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
