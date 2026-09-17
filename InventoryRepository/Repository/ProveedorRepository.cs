using AutoMapper;
using InventoryModels.DTO;
using InventoryRepository.DataModels;

namespace InventoryRepository.Repository
{
    public class ProveedorRepository(BaseRepository<Proveedores> repo, IMapper mapper)
    {
        private readonly IMapper _mapper = mapper;
        private readonly BaseRepository<Proveedores> _repo = repo;

        public async Task<ProveedorDTO> AddProveedor(ProveedorDTO req)
        {
            var modelo = _mapper.Map<Proveedores>(req);
            var newProv = await _repo.Crear(modelo);
            return _mapper.Map<ProveedorDTO>(newProv);
        }

        public async Task<List<ProveedorDTO>> GetList()
        {
            var query = await _repo.Consultar();
            return _mapper.Map<List<ProveedorDTO>>(query);
        } 

        public async Task<ProveedorDTO> GetById(int id)
        {
            var query = await _repo.Consultar(p => p.Id == id);
            return _mapper.Map<ProveedorDTO>(query.FirstOrDefault());
        }
    }
}
