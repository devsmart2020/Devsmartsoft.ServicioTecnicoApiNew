using System;
using System.Collections.Generic;

namespace Devsmartsoft.ServicioTecnicoApi.Core.Domain.Entities;

public partial class VentaDetalle
{
    public Guid VentaId { get; set; }

    public Guid ServicioId { get; set; }

    public int Cantidad { get; set; }

    public decimal Valor { get; set; }

    public string? Descripcion { get; set; }

    public virtual Servicio Servicio { get; set; } = null!;

    public virtual Venta Venta { get; set; } = null!;
}
