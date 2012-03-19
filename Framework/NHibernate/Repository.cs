using System;
using System.Collections.Generic;
using System.Linq;
using BA.MultiMVC.Framework.NHibernate;
using NHibernate;
using NHibernate.Linq;

namespace BA.MultiMvc.Framework.NHibernate
{
    public class Repository:IRepository
    {
        protected ISession _session;
        private ITransaction _trx;

        public Repository()
        {
            try
            {
                _session = NHHelper.GetSessionFactoryFor(TenantContext.TenantKey).GetCurrentSession();
            }
            catch (NullReferenceException)
            {
                _session = NHHelper.GetSessionFactoryFor(TenantContext.TenantKey).OpenSession();
            }
            _trx = _session.BeginTransaction();
        }

        public Repository(ISession session)
        {
            _session = session;
            _trx = session.BeginTransaction();
        }
        
        public void Save(Entity entity)
        {
            _session.Save(entity);
        }

        public void Delete(Entity entity)
        {
            _session.Delete(entity);
        }
        
        public void Commit()
        {
            _trx.Commit();
            _trx = _session.BeginTransaction();
        }

        public void Revert()
        {
            _trx.Dispose();
            _trx = _session.BeginTransaction();
        }
    }

    public class Repository<T>:Repository, IRepository<T> where T : Entity
    {
        public Repository():base()
        {}

        public Repository(ISession session):base(session)
        {}

        public T GetById(Guid id)
        {
             var query = from o in _session.Query<T>()
                        where o.Id == id
                        select o;
            return query.SingleOrDefault();        
        }

        public T GetBy(Func<T,bool> predicate)
        {
            var query = _session.Query<T>().Where(predicate);
            return query.FirstOrDefault();
        }

        public void Save(T entity)
        {
            _session.Save(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }

    public class Repository<T,TId> : Repository, IRepository<T,TId> where T : Entity<TId>
    {
        public Repository()
            : base()
        { }

        public Repository(ISession session)
            : base(session)
        { }

        public T GetById(TId id)
        {
            var query = from o in _session.Query<T>()
                        where EqualityComparer<TId>.Default.Equals(o.Id,id)
                        select o;
            return query.SingleOrDefault();
        }

        public T GetBy(Func<T, bool> predicate)
        {
            var query = _session.Query<T>().Where(predicate);
            return query.FirstOrDefault();
        }

        public void Save(T entity)
        {
            _session.Save(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }


}
