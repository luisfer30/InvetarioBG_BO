using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.DTO
{
    public class StockDTO
    {
        public int ProductoId { get; set; }

        public string Producto { get; set; } = string.Empty;

        public int ProveedorId { get; set; }

        public string Proveedor { get; set; } = string.Empty;

        public decimal PrecioUnitario { get; set; }

        public int Cantidad { get; set; }
    }
}
