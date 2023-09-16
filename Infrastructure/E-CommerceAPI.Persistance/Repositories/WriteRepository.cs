using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities.Common;
using E_CommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace E_CommerceAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly ECommerceDbContext _context;

        public WriteRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
          EntityEntry<T> entityEntry =  await Table.AddAsync(entity);
           return entityEntry.State == EntityState.Added;
        }
           

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            await Table.AddRangeAsync(entity);            
            return true;
            
        }
           

      public bool Delete(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
     
        }

       public async Task<bool> DeleteAsync(string id)
        {
          T model = await  Table.FirstOrDefaultAsync(data=> data.Id== Guid.Parse(id));
            return Delete(model);


        }
        public bool DeleteRange(List<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

       public  bool Update(T entity)
        {
            EntityEntry<T> entityEntry =  Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveChanges()
        {
            
            return await _context.SaveChangesAsync();
        }

        
    }
}
