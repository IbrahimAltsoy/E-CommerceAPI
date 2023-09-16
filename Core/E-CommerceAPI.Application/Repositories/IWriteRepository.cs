using E_CommerceAPI.Domain.Entities.Common;

namespace E_CommerceAPI.Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T> where T : BaseEntity, new()
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddAsync(List<T> entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> Delete(T entity);
        Task<bool> Delete(string id);
    }
}
