using InventoryModels.DTO;
using InventoryRepository.DataModels;


namespace InventoryRepository.Repository
{
    public class StockRepository(BaseRepository<Stock> repo)
    {
        private readonly BaseRepository<Stock> _repo = repo;

        public async Task<List<StockDTO>> GetStock()
        {
            return [];
        }
    }
}
