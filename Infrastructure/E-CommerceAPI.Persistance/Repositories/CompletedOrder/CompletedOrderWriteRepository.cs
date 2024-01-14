using C= E_CommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_CommerceAPI.Application.Repositories.CompletedOrder;
using E_CommerceAPI.Persistance.Contexts;

namespace E_CommerceAPI.Persistance.Repositories.CompletedOrder
{
    public class CompletedOrderWriteRepository : WriteRepository<C.CompletedOrder>, ICompletedOrderWriteRepository
    {
        public CompletedOrderWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
