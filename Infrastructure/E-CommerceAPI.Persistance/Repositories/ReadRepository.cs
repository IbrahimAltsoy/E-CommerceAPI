using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities.Common;
using E_CommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Linq.Expressions;

namespace E_CommerceAPI.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly ECommerceDbContext _context;

        public ReadRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
      

        public async Task<T> GetByIdAsync(string id, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(p=> p.Id==Guid.Parse(id));
        }
           

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
            

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking)
        {
            var query = Table.Where(method);
            if(!tracking) query = query.AsNoTracking();
            return query;
        }
    }
}
