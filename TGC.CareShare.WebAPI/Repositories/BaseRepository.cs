using Microsoft.EntityFrameworkCore;
using TGC.CareShare.WebAPI.Models.DataModels;

namespace TGC.CareShare.WebAPI.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: DTOBaseClass 
    {
        private readonly CareShareDBContext _careShareDBContext;
        protected DbSet<T> Context;

        public BaseRepository(CareShareDBContext careShareDBContext)
        {
            _careShareDBContext = careShareDBContext;
            Context = _careShareDBContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Context.FirstAsync(t => t.Id == id);
        }

        public async Task<List<Guid>> GetAllIdsAsync()
        {
            return await Context.Select(t => t.Id).ToListAsync();
        }

        public async Task<T> CreateAsync(T t)
        {
            var entity = await Context.AddAsync(t);
            return entity.Entity;
        }

        public T Update(T t)
        {
            return Context.Update(t).Entity;
        }
    }
}
