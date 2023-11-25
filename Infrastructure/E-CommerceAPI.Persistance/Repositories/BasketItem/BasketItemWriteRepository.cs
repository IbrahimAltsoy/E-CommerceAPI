using E_CommerceAPI.Application.Repositories.BasketItem;
using E_CommerceAPI.Persistance.Contexts;
using B=E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.BasketItem
{
    public class BasketItemWriteRepository : WriteRepository<B.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
