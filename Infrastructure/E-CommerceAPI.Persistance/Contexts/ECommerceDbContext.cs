using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Persistance.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
           
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker Entitiler üzerinde yeni ekleme ve  yapılan değişiklikleri yakalayan propertidir.
            var values = ChangeTracker.Entries<BaseEntity>();
            foreach(var value in values)
            {
                _ = value.State switch
                {
                    EntityState.Added => value.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => value.Entity.UpdateDate = DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
