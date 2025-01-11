using Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;
using Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.Resources;
using Microsoft.EntityFrameworkCore;

namespace Devsmartsoft.ServicioTecnicoApi.Infrastructure.Persistence.EntityFramework
{
    public partial class DbServiciotecnicoContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ResourcesPersistence.Db_localConn ?? throw new Exception("DbConn is null"),
                    sqlServerOptionsAction: SqlOptions =>
                    {
                        SqlOptions.EnableRetryOnFailure();
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.ClienteId).ValueGeneratedNever();
                entity.Property(e => e.Apellidos).HasMaxLength(80);
                entity.Property(e => e.CodigoUtilidad).HasMaxLength(6);
                entity.Property(e => e.DocId).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.EmailAlterno).HasMaxLength(150);
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.IdDispositivo).HasMaxLength(128);
                entity.Property(e => e.Nombres).HasMaxLength(80);
                entity.Property(e => e.Pass).HasMaxLength(512);
                entity.Property(e => e.Telefono).HasMaxLength(10);
                entity.Property(e => e.TelefonoAlterno).HasMaxLength(10);
                entity.Property(e => e.TipoDispositivo).HasMaxLength(10);
            });

            modelBuilder.Entity<Configuracion>(entity =>
            {
                entity.ToTable("Configuracion");

                entity.Property(e => e.ConfiguracionId).ValueGeneratedNever();
                entity.Property(e => e.RutaFirebase).HasMaxLength(500);
                entity.Property(e => e.RutaSeguridad).HasMaxLength(500);
            });

            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.ToTable("Elemento");

                entity.Property(e => e.ElementoId).ValueGeneratedNever();
                entity.Property(e => e.Color).HasMaxLength(20);
                entity.Property(e => e.Descripcion).HasMaxLength(400);
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.ImagenUrl).HasMaxLength(1500);
                entity.Property(e => e.Marca).HasMaxLength(30);
                entity.Property(e => e.Modelo).HasMaxLength(60);
                entity.Property(e => e.Serial).HasMaxLength(60);
                entity.Property(e => e.Tipo).HasMaxLength(60);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado");

                entity.HasKey(e => e.EstadoId);
                entity.Property(e => e.EstadoId).ValueGeneratedOnAdd();
                entity.Property(e => e.Descripcion).HasMaxLength(30);
                entity.Property(e => e.Nombre).HasMaxLength(60);
            });

            modelBuilder.Entity<Evidencia>(entity =>
            {
                entity.HasKey(e => e.EvidenciaId);

                entity.Property(e => e.EvidenciaId).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasMaxLength(150);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Nombre).HasMaxLength(40);

                entity.HasOne(d => d.Servicio).WithMany(p => p.Evidencia)
                    .HasForeignKey(d => d.ServicioId)
                    .HasConstraintName("FK_Evidencia_Servicio");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.ToTable("FormaPago");

                entity.Property(e => e.FormaPagoId).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasMaxLength(30);
                entity.Property(e => e.Nombre).HasMaxLength(20);
            });

            modelBuilder.Entity<Gasto>(entity =>
            {
                entity.ToTable("Gasto");

                entity.Property(e => e.GastoId).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasMaxLength(200);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.FechaPago).HasColumnType("datetime");
                entity.Property(e => e.Nombre).HasMaxLength(30);
                entity.Property(e => e.Valor).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.TipoGasto).WithMany(p => p.Gastos)
                    .HasForeignKey(d => d.TipoGastoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Gasto_TipoGasto");
            });

            modelBuilder.Entity<MovimientoRepuesto>(entity =>
            {
                entity.HasKey(e => new { e.ServicioId, e.RepuestoId });

                entity.ToTable("MovimientoRepuesto");

                entity.Property(e => e.Cantidad).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.CostoRepuesto).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.ValorUnitarioRepuesto).HasColumnType("decimal(12, 3)");

                entity.HasOne(d => d.Repuesto).WithMany(p => p.MovimientoRepuestos)
                    .HasForeignKey(d => d.RepuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoRepuesto_Repuesto");

                entity.HasOne(d => d.Servicio).WithMany(p => p.MovimientoRepuestos)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MovimientoRepuesto_Servicio");
            });

            modelBuilder.Entity<Novedad>(entity =>
            {
                entity.ToTable("Novedad");

                entity.Property(e => e.NovedadId).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasMaxLength(400);
                entity.Property(e => e.EvidenciasUrl).HasMaxLength(1500);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.FechaAprobacion).HasColumnType("datetime");
                entity.Property(e => e.FechaCierre).HasColumnType("datetime");
                entity.Property(e => e.FechaRechazo).HasColumnType("datetime");
                entity.Property(e => e.NotaCierre).HasMaxLength(150);
                entity.Property(e => e.NotaCliente).HasMaxLength(150);

                entity.HasOne(d => d.Servicio).WithMany(p => p.Novedads)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Novedad_Servicio");
            });

            modelBuilder.Entity<Repuesto>(entity =>
            {
                entity.ToTable("Repuesto");

                entity.Property(e => e.RepuestoId).ValueGeneratedNever();
                entity.Property(e => e.AlertaMaximo).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.AlertaMinimo).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.CantidadStock).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.CodigoBarras).HasMaxLength(30);
                entity.Property(e => e.Consecutivo).HasMaxLength(10);
                entity.Property(e => e.Costo).HasColumnType("decimal(12, 3)");
                entity.Property(e => e.Descripcion).HasMaxLength(150);
                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");
                entity.Property(e => e.Marca).HasMaxLength(20);
                entity.Property(e => e.Modelo).HasMaxLength(90);
                entity.Property(e => e.Nombre).HasMaxLength(90);
                entity.Property(e => e.Serial).HasMaxLength(30);
                entity.Property(e => e.Tipo).HasMaxLength(20);
                entity.Property(e => e.Ubicacion).HasMaxLength(20);
                entity.Property(e => e.ValorUnitario).HasColumnType("decimal(12, 3)");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("Servicio");

                entity.Property(e => e.ServicioId).ValueGeneratedNever();
                entity.Property(e => e.ConsecutivoServicio).HasMaxLength(20);
                entity.Property(e => e.Descripcion).HasMaxLength(1500);
                entity.Property(e => e.DescripcionReparacion).HasMaxLength(400);
                entity.Property(e => e.EvidenciaReparacionUrl).HasMaxLength(1500);
                entity.Property(e => e.FechaAbono).HasColumnType("datetime");
                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
                entity.Property(e => e.FechaFin).HasColumnType("datetime");
                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
                entity.Property(e => e.NotaTecnico).HasMaxLength(400);
                entity.Property(e => e.QrCode).HasMaxLength(1500);
                entity.Property(e => e.ValorAbono).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.ValorPagar).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio_Cliente");

                entity.HasOne(d => d.Elemento)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.ElementoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio_Elemento");

                entity.HasOne(d => d.Estado)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.EstadoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio_Estado");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Servicios)
                    .HasForeignKey(d => d.TecnicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servicio_Tecnico");
            });

            modelBuilder.Entity<ServicioTrazabilidad>(entity =>
            {
                entity.HasKey(e => e.TrazabilidadId);

                entity.ToTable("ServicioTrazabilidad");

                entity.Property(e => e.TrazabilidadId).ValueGeneratedNever();
                entity.Property(e => e.DescripcionReparacion).HasMaxLength(400);
                entity.Property(e => e.FechaAbono).HasColumnType("datetime");
                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");
                entity.Property(e => e.FechaFin).HasColumnType("datetime");
                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
                entity.Property(e => e.FechaInicio).HasColumnType("datetime");
                entity.Property(e => e.ValorAbono).HasColumnType("decimal(18, 3)");
                entity.Property(e => e.ValorPagar).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Servicio).WithMany(p => p.ServicioTrazabilidads)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicioTrazabilidad_Servicio");

                entity.HasOne(d => d.Tecnico).WithMany(p => p.ServicioTrazabilidads)
                    .HasForeignKey(d => d.TecnicoId)
                    .HasConstraintName("FK_ServicioTrazabilidad_Tecnico");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("Tecnico");

                entity.Property(e => e.TecnicoId).ValueGeneratedNever();
                entity.Property(e => e.Apellidos).HasMaxLength(80);
                entity.Property(e => e.CentroServicio).HasMaxLength(90);
                entity.Property(e => e.CodigoUtilidad).HasMaxLength(6);
                entity.Property(e => e.DocId).HasMaxLength(15);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.IdDispositivo).HasMaxLength(128);
                entity.Property(e => e.Nombres).HasMaxLength(80);
                entity.Property(e => e.Pass).HasMaxLength(256);
                entity.Property(e => e.Telefono).HasMaxLength(10);
                entity.Property(e => e.TipoDispositivo).HasMaxLength(10);
                entity.Property(e => e.Usuario).HasMaxLength(20);
            });

            modelBuilder.Entity<TipoGasto>(entity =>
            {
                entity.ToTable("TipoGasto");

                entity.Property(e => e.TipoGastoId).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasMaxLength(80);
                entity.Property(e => e.Nombre).HasMaxLength(40);
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.ToTable("Ubicacion");

                entity.Property(e => e.Direccion).HasMaxLength(150);
                entity.Property(e => e.DireccionCompleta).HasMaxLength(250);
                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.GeoIp).HasMaxLength(20);
                entity.Property(e => e.Observaciones).HasMaxLength(150);
                entity.Property(e => e.Pais).HasMaxLength(5);
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasKey(e => new { e.VentaId, e.ServicioId });

                entity.ToTable("VentaDetalle");

                entity.Property(e => e.Descripcion).HasMaxLength(150);
                entity.Property(e => e.Valor).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Servicio).WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.ServicioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaDetalle_Servicio");

                entity.HasOne(d => d.Venta).WithMany(p => p.VentaDetalles)
                    .HasForeignKey(d => d.VentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VentaDetalle_Venta");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.VentaId);

                entity.Property(e => e.VentaId).ValueGeneratedNever();
                entity.Property(e => e.CentroServicioCiudad).HasMaxLength(80);
                entity.Property(e => e.CentroServicioDireccion).HasMaxLength(150);
                entity.Property(e => e.CentroServicioEmail).HasMaxLength(150);
                entity.Property(e => e.CentroServicioNit).HasMaxLength(20);
                entity.Property(e => e.CentroServicioNombre).HasMaxLength(150);
                entity.Property(e => e.CentroServicioPaginaWeb).HasMaxLength(200);
                entity.Property(e => e.CentroServicioTelefono).HasMaxLength(10);
                entity.Property(e => e.CentroServicioTelefonoAlterno).HasMaxLength(10);
                entity.Property(e => e.ConsecutivoId).HasMaxLength(10);
                entity.Property(e => e.DocIdCliente).HasMaxLength(15);
                entity.Property(e => e.Fecha).HasColumnType("datetime");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NombreCliente).HasMaxLength(170);

                entity.HasOne(d => d.FormaPago).WithMany(p => p.Venta)
                    .HasForeignKey(d => d.FormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Venta_FormaPago");
            });
        }
    }
}
