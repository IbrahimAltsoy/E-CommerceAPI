using E_CommerceAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
       DbSet<T> Table { get; }

    }
}
