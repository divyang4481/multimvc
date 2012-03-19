using System;

namespace BA.MultiMvc.Framework.NHibernate
{
    public interface IRepository : ITenantModel
    {
        void Save(Entity entity);

        void Commit();
        void Delete(Entity entity);
        void Revert();

    }

    public interface IRepository<T> : IRepository where T : Entity
    {
        T GetById(Guid id);
        T GetBy(Func<T,bool> predicate);

        void Save(T entity);
        void Delete(T entity);
    }

    public interface IRepository<T, TId>:IRepository where T : Entity<TId>
    {
        T GetById(TId id);
        T GetBy(Func<T, bool> predicate);

        void Save(T entity);
        void Delete(T entity);
    }
}
