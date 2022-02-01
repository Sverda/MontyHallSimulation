using Domain.Common;

namespace Application.Repositories
{
    public interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        TEntity GetById(TId id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
