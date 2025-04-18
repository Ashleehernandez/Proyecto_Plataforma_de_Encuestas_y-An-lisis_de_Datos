using CapDominio.Entity;
using CapInfraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace CapInfraestructura.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ContextoDB _context;
        private DbSet<T> Entity { get; set; }

        public GenericRepository(ContextoDB contexto)
        {
            _context = contexto;
            Entity = _context.Set<T>();

        }

        public virtual async Task Add(T entity)
        {
            try
            {
                await Entity.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public virtual async Task<object> AddAndReturnId(T entity)
        {
            try
            {
                var res = await Entity.AddAsync(entity);
                await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public virtual async Task Delete(int id)
        {
            var entity = await Entity.FindAsync(id);
            if (entity is not null)
            {
                Entity.Remove(entity);
            }
            else
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }

            await _context.SaveChangesAsync();


        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Entity.ToListAsync<T>();

        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await Entity.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            return entity;
        }

        public virtual async Task Update(T entity)
        {
            var entry = _context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Entity.Attach(entity);
            }
            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
