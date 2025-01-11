using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories.Base;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories
{
    public sealed class VentaDetalleRepository : BaseRepository<VentaDetalle>, IVentaDetalleRepository
    {
        #region Fields

        #endregion

        #region Ctor
        public VentaDetalleRepository(DbServiciotecnicoContext context) : base(context)
        {

        }
        #endregion

        #region Methods

        #endregion
    }
}
