using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Models.Infrastructure;

namespace BA.MultiMVC.Sample.Extensions.Contoso.Model.Infrasturcture
{
    public class ContosoMembershipService:MembershipService
    {
        public ContosoMembershipService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
