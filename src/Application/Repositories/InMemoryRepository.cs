using Domain.Common;

namespace Application.Repositories
{
    internal class InMemoryRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : IComparable<TId>
    {
        protected readonly List<TEntity> entities = new();

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public TEntity GetById(TId id)
        {
            return entities.Single(x => x.Id.Equals(id));
        }

        public void Remove(TEntity entity)
        {
            entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            entities.Remove(entity);
            entities.Add(entity);
        }
    }
}
