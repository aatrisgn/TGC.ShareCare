namespace TGC.CareShare.WebAPI.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(Guid id);

        Task<T> CreateAsync(T t);

        Task<List<Guid>> GetAllIdsAsync();
        T Update(T t);
    }
}
