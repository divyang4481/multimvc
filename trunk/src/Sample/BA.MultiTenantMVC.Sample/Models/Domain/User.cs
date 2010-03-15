using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain
{
    public class User:ITenantModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        #region ITenantModel Members

        public TenantContext Context
        {
            get; set;
        }

        #endregion
    }
}