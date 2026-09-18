using InventoryRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace InventoryRepository.Repository
{
    public class BaseRepository <T>(InventoryContext context) where T : class
    {
        private readonly InventoryContext _context = context;

        public async Task<List<T>> Consultar(Expression<Func<T, bool>>? filtro = null)
        {
            var query = filtro == null ?  _context.Set<T>() : _context.Set<T>().Where(filtro);
            return await query.ToListAsync();
        }
        public async Task<List<T>> ConsultarConIncludes(Expression<Func<T, bool>>? filtro = null,params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context
                .Set<T>()
                .AsNoTracking();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T> Crear(T modelo)
        {
            _context.Set<T>().Add(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }
        
        public async Task<bool> Actualizar(Expression<Func<SetPropertyCalls<T>,SetPropertyCalls<T>>> expression
                                         ,Expression<Func<T, bool>> filtro)
        {
            try
            {
                await _context.Set<T>().Where(filtro).ExecuteUpdateAsync(expression);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Eliminar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                var filasAfectadas = await _context
                    .Set<T>()
                    .Where(filtro)
                    .ExecuteDeleteAsync();

                return filasAfectadas > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
