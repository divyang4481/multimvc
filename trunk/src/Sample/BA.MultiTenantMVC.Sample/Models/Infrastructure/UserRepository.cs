using System;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Sample.Models.Infrastructure.Linq;

namespace BA.MultiMvc.Sample.Models.Infrastructure
{
    public class UserRepository:IUserRepository 
    {
        string _client;

        protected DBDataContext DataContext;

        #region public method
        
        public void Save(BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain.User user)
        {
            throw new NotImplementedException();
        }

        public void Load(string userName)
        {
            throw new NotImplementedException();
        }

        #endregion



        #region ITenantModel Members

        private TenantContext _context;
        public TenantContext Context
        {
            get { return _context; }
            set
            {
                _context = value;
                DataContext = new DBDataContext(_context.ConnectionString);
            }
        }

        #endregion
    }
}