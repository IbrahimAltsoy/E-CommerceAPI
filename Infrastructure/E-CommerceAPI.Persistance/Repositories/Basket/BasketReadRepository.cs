using E_CommerceAPI.Application.Repositories.Basket;
using E_CommerceAPI.Persistance.Contexts;
using B=E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.Basket
{
    public class BasketReadRepository : ReadRepository<B.Basket>, IBasketReadRepository
    {
        public BasketReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
