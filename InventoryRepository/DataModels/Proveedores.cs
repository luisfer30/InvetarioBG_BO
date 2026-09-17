using System;
using System.Collections.Generic;

namespace InventoryRepository.DataModels;

public partial class Proveedores
{
    public int Id { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
