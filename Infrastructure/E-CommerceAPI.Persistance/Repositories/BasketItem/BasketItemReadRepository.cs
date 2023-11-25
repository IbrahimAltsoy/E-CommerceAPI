using E_CommerceAPI.Application.Repositories.BasketItem;
using E_CommerceAPI.Persistance.Contexts;
using B=E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.BasketItem
{
    public class BasketItemReadRepository : ReadRepository<B.BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
