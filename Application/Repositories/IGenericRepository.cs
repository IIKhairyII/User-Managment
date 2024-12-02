using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> condition);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
