using Devsmartsoft.ServicioTecnicoApi.Core.Domain.CommonEntities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Core.Domain.RepositoryInterfaces;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Repositories
{
    public sealed class ServicioRepository : BaseRepository<Servicio>, IServicioRepository
    {
        #region Fields

        #endregion

        #region Ctor
        public ServicioRepository(DbServiciotecnicoContext context) : base(context)
        {

        }
        #endregion

        #region Methods
        public async Task<IEnumerable<ServicioReporte>> ListarPorFiltro(SearchOrderFilter filter)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(filter.SearchText))
            {
                query = query.Where(x => x.Cliente.DocId == filter.SearchText);
            }

            if (!string.IsNullOrEmpty(filter.ServiceNumber))
            {
                query = query.Where(x => x.ConsecutivoServicio == filter.ServiceNumber);
            }

            if (filter.Techinician != Guid.Empty)
            {
                query = query.Where(x => x.TecnicoId == filter.Techinician);
            }

            if (filter.State != 0)
            {
                query = query.Where(x => x.EstadoId == filter.State);
            }

            if (filter.DateStart != DateTime.MinValue && filter.DateEnd != DateTime.MinValue)
            {
                query = query.Where(x => x.FechaIngreso.Date >= filter.DateStart.Date && x.FechaIngreso.Date <= filter.DateEnd.Date);
            }
            else if (filter.DateStart != DateTime.MinValue)
            {
                query = query.Where(x => x.FechaIngreso.Date >= filter.DateStart.Date);
            }
            else if (filter.DateEnd != DateTime.MinValue)
            {
                query = query.Where(x => x.FechaIngreso.Date <= filter.DateEnd.Date);
            }

            var result = await query
                .Select(x => new ServicioReporte
                {
                    Servicio = new Servicio
                    {
                        ServicioId = x.ServicioId,
                        ConsecutivoServicio = x.ConsecutivoServicio,
                        TecnicoId = x.TecnicoId,
                        EstadoId = x.EstadoId,
                        EvidenciaId = x.EvidenciaId,
                        FechaIngreso = x.FechaIngreso,
                        FechaInicio = x.FechaInicio,
                        FechaFin = x.FechaFin,
                        FechaEntrega = x.FechaEntrega,
                        PorcentajeAvance = x.PorcentajeAvance,
                        ValorPagar = x.ValorPagar,
                        ValorAbono = x.ValorAbono,
                        FechaAbono = x.FechaAbono,
                        QrCode = x.QrCode,
                        Descripcion = x.Descripcion,
                        DescripcionReparacion = x.DescripcionReparacion,
                        EvidenciaReparacionUrl = x.EvidenciaReparacionUrl,
                        Finalizada = x.Finalizada,
                        NotaTecnico = x.NotaTecnico,
                        UsuarioCreacion = x.UsuarioCreacion
                    },
                    Cliente = new Cliente
                    {
                        ClienteId = x.Cliente.ClienteId,
                        Nombres = x.Cliente.Nombres,
                        Apellidos = x.Cliente.Apellidos,
                        Telefono = x.Cliente.Telefono,
                        Email = x.Cliente.Email,
                        IdDispositivo = x.Cliente.IdDispositivo,
                        TipoDispositivo = x.Cliente.TipoDispositivo
                    },
                    Elemento = new Elemento
                    {
                        ElementoId = x.Elemento.ElementoId,
                        Tipo = x.Elemento.Tipo,
                        Marca = x.Elemento.Marca,
                        Modelo = x.Elemento.Modelo,
                        Serial = x.Elemento.Serial,
                        Color = x.Elemento.Color,
                        ImagenUrl = x.Elemento.ImagenUrl,
                        Descripcion = x.Elemento.Descripcion,
                        FechaCreacion = x.Elemento.FechaCreacion
                    },
                    Ubicacion = new Ubicacion
                    {
                        Id = x.Cliente.Ubicacions.First().Id,
                        ClienteId = x.Cliente.Ubicacions.First().ClienteId,
                        Ciudad = x.Cliente.Ubicacions.First().Ciudad,
                        Pais = x.Cliente.Ubicacions.First().Pais,
                        Region = x.Cliente.Ubicacions.First().Region,
                        Direccion = x.Cliente.Ubicacions.First().Direccion,
                        DireccionCompleta = x.Cliente.Ubicacions.First().DireccionCompleta,
                        GeoIp = x.Cliente.Ubicacions.First().GeoIp,
                        Observaciones = x.Cliente.Ubicacions.First().Observaciones,
                        Estado = x.Cliente.Ubicacions.First().Estado
                    },
                    ElementoDetalle = $"{x.Elemento.Tipo} {x.Elemento.Marca} {x.Elemento.Modelo}",
                    Tecnico = $"{x.Tecnico.Nombres} {x.Tecnico.Apellidos}",
                    Estado = x.Estado.Nombre
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Servicio.FechaIngreso)
                .ToListAsync();

            return result;
        }
        #endregion
    }
}
