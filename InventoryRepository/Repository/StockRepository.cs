using InventoryModels.DTO;
using InventoryRepository.DataModels;


namespace InventoryRepository.Repository
{
    public class StockRepository(BaseRepository<Stock> repo)
    {
        private readonly BaseRepository<Stock> _repo = repo;

        public async Task<List<StockDTO>> GetStock()
        {
            var query = await _repo.ConsultarConIncludes(
                null,
                x => x.Producto,
                x => x.Proveedor
            );

            return query
                .Select(x => new StockDTO
                {
                    ProductoId = x.ProductoId,
                    Producto = x.Producto.Nombre,

                    ProveedorId = x.ProveedorId,
                    Proveedor = x.Proveedor.RazonSocial,

                    PrecioUnitario = x.PrecioUnitario,
                    Cantidad = x.Cantidad
                })
                .ToList();
        }
        public async Task<StockDTO> AddStock(StockDTO req)
        {
            var model = new Stock
            {
                ProductoId = req.ProductoId,
                ProveedorId = req.ProveedorId,
                PrecioUnitario = req.PrecioUnitario,
                Cantidad = req.Cantidad
            };

            var newStock = await _repo.Crear(model);

            return new StockDTO
            {
                ProductoId = newStock.ProductoId,
                ProveedorId = newStock.ProveedorId,
                PrecioUnitario = newStock.PrecioUnitario,
                Cantidad = newStock.Cantidad
            };
        }
    }
}
