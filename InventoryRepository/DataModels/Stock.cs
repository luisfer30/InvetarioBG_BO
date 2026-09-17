using System;
using System.Collections.Generic;

namespace InventoryRepository.DataModels;

public partial class Stock
{
    public int ProductoId { get; set; }

    public int ProveedorId { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int Cantidad { get; set; }

    public virtual Productos Producto { get; set; } = null!;

    public virtual Proveedores Proveedor { get; set; } = null!;
}
