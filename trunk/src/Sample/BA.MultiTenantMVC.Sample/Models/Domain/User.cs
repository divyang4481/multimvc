using BA.MultiMVC.Framework.Core;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Domain
{
    public class User:IModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}