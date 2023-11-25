using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Domain.Entities.Common;
using E_CommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Persistance.Contexts
{
    public class ECommerceDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
           
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>()
                .HasKey(b => b.Id);
            builder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithOne(b => b.Basket)
                .HasForeignKey<Order>(b => b.Id);
            base.OnModelCreating(builder);
        }

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
                    _=>DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
