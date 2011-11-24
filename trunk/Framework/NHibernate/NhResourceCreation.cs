using System.Collections.Generic;
using System.Linq;
using BA.MultiMvc.Framework.NHibernate;
using NHibernate;

namespace BackToOwner.Web.Setup
{
    public interface IResourceCreation
    {
        void InsertOrUpdate();
    }

    public abstract class NHResourceCreation : IResourceCreation
    {
        private ISession _currentSession;
        public NHResourceCreation(ISession currentSession)
        {
            _currentSession = currentSession;
        }

        public void InsertOrUpdate()
        {
            IEnumerable<Resource> resources = GetResources();
            foreach (var resource in resources)
            {
                var query = _currentSession.QueryOver<Resource>()
                            .Where(n=>n.Language == resource.Language && n.Label==resource.Label)
                            .List();

                if(query.Count()<1)
                {
                    _currentSession.Save(resource);
                }
                else
                {
                    var oldResource = query.First();
                    oldResource.Value = resource.Value;
                    _currentSession.Save(oldResource);
                }
            }
        }

        protected abstract IEnumerable<Resource> GetResources();

    }
}