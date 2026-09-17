using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels.DTO
{
    public class StockDTO
    {
        public List<ProductoDTO> Productos { get; set; } = [];
        public List<ProveedorDTO> Proveedores { get; set; } = [];
    }
}
