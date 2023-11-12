using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Contexts;

namespace E_CommerceAPI.Persistance.Repositories
{
    public class UserReadRepository : ReadRepository<Product>, IUserReadRepository
    {
        public UserReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
