using System;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure
{
    public class MembershipService:IMembershipService
    {
        //Need constructor to enable structuremap to inject default repository
        public MembershipService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        #region public properties
        //Need property to enable structuremap to inject named instance
        public IUserRepository UserRepository
        {
            get;
            set;
        }

        #endregion

        #region public methods
        public void Register(User user)
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IService Members

        public TenantContext Context { get; set; }

        #endregion
    }
}
