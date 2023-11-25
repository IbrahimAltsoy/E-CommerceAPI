using E_CommerceAPI.Application.Repositories;
using E_CommerceAPI.Application.Repositories.Basket;
using E_CommerceAPI.Persistance.Contexts;
using B = E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.Basket
{
    public class BasketWriteRepository : WriteRepository<B.Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
