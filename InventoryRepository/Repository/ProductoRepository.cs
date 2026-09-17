using AutoMapper;
using InventoryModels.DTO;
using InventoryRepository.DataModels;

namespace InventoryRepository.Repository
{
    public class ProductoRepository(BaseRepository<Productos> repo, IMapper mapper)
    {
        private readonly IMapper _mapper = mapper;
        private readonly BaseRepository<Productos> _repo = repo;

        public async Task<ProductoDTO> AddProducto(ProductoDTO req)
        {
            var modelo = _mapper.Map<Productos>(req);
            var newProduct = await _repo.Crear(modelo);
            return _mapper.Map<ProductoDTO>(newProduct);
        }

        public async Task<List<ProductoDTO>> GetList()
        {
            var query = await _repo.Consultar();
            return _mapper.Map<List<ProductoDTO>>(query);
        }

        public async Task<ProductoDTO> GetById(int id)
        {
            var query = await _repo.Consultar(p => p.Id == id);
            return _mapper.Map<ProductoDTO>(query.FirstOrDefault());
        } 
    }
}
