using E_CommerceAPI.Application.Repositories.CompletedOrder;
using E_CommerceAPI.Persistance.Contexts;
using C=E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Persistance.Repositories.CompletedOrder
{
    public class CompletedOrderReadRepository : ReadRepository<C.CompletedOrder>, ICompletedOrderReadRepository
    {
        public CompletedOrderReadRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
