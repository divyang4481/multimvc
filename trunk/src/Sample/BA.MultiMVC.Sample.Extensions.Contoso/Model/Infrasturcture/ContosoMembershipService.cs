using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework;
using BA.MultiMvc.Sample.Models.Infrastructure;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Model.Infrasturcture
{
    public class ContosoMembershipService:IMembershipService
    {
        private IUserRepository _userRepository;

        public ContosoMembershipService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public IUserRepository UserRepository
        { 
            get{ return _userRepository;}
            set { _userRepository = value; }
        }

       

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
