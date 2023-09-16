using System.Linq.Expressions;
using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>>method);
        Task<T> GetSingleAsync(Expression<Func<T, bool>>method);
        Task<T> GetByIdAsync(string id);
    }
}
