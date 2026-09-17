using InventoryRepository.DataModels;
using InventoryModels.Request;
using InventoryRepository.Exceptions;

namespace InventoryRepository.Repository
{
    public class UsuarioRepository(BaseRepository<Usuario> repo)
    {
        private readonly BaseRepository<Usuario> _repo = repo;

        public async Task<bool> ValidarCredenciales(LoginRequest request)
        {
            var query = await _repo.Consultar(x => x.Correo == request.Correo && x.Password == request.Password);

            if (query == null || query.Count <= 0) throw new NotFoundException("Usuario o contraseña incorrectos");

            return true;
        }
    }
}
