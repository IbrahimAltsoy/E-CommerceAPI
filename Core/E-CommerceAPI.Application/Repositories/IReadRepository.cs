using System.Linq.Expressions;
using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool tracking);
        IQueryable<T> GetWhere(Expression<Func<T, bool>>method, bool tracking);
        Task<T> GetSingleAsync(Expression<Func<T, bool>>method, bool tracking);
        Task<T> GetByIdAsync(string id, bool tracking);
    }
}
