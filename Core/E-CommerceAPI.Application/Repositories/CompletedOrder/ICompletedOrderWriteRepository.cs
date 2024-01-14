using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = E_CommerceAPI.Domain.Entities;

namespace E_CommerceAPI.Application.Repositories.CompletedOrder
{
    public interface ICompletedOrderWriteRepository: IWriteRepository<C.CompletedOrder>
    {
    }
}
