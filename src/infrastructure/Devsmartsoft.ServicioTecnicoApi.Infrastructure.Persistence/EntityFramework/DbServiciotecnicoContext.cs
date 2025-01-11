using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework;

public partial class DbServiciotecnicoContext : DbContext
{
    public DbServiciotecnicoContext()
    {
    }

    public DbServiciotecnicoContext(DbContextOptions<DbServiciotecnicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Evidencia> Evidencia { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Gasto> Gastos { get; set; }

    public virtual DbSet<MovimientoRepuesto> MovimientoRepuestos { get; set; }

    public virtual DbSet<Novedad> Novedads { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioTrazabilidad> ServicioTrazabilidads { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    public virtual DbSet<TipoGasto> TipoGastos { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }
}
