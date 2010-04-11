using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Model.Infrasturcture
{
    public class ContosoMembershipService:IMembershipService
    {
        public ContosoMembershipService(IUserRepository userRepository) 
        {
        }

        #region IMembershipService Members

        public IUserRepository UserRepository
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Register(BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Domain.User user)
        {
            throw new NotImplementedException();
        }

        public bool Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ITenantModel Members

        public BA.MultiMvc.Framework.TenantContext Context
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
