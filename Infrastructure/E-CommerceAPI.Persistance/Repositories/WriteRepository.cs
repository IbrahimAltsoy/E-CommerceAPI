using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities.Common;
using E_CommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
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
            await Table.AddAsync(entity);
           await _context.SaveChangesAsync();
            return true;
        }
           

        Task<bool> IWriteRepository<T>.AddAsync(List<T> entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IWriteRepository<T>.Delete(T entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IWriteRepository<T>.Delete(string id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IWriteRepository<T>.UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
