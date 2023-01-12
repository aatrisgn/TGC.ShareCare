using System.Linq.Expressions;

namespace TGC.CareShare.WebAPI.Repositories;

public interface IBaseRepository<T>
{
    Task<T> GetByIdAsync(Guid id);

    Task<T> CreateAsync(T t);

    Task<List<Guid>> GetAllIdsAsync();
    Task<T> Update(T t);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsByIdAsync(Guid id);
}
