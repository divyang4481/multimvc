using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;
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
            get; set;
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
            get; set;
        }

        #endregion

        #region IMembershipService Members

        public int MinPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public System.Web.Security.MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
