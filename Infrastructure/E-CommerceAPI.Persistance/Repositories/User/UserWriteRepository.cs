using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Domain.Entities;
using E_CommerceAPI.Persistance.Contexts;

namespace E_CommerceAPI.Persistance.Repositories
{
    public class UserWriteRepository : WriteRepository<Product>, IUserWriteRepository
    {
        public UserWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
