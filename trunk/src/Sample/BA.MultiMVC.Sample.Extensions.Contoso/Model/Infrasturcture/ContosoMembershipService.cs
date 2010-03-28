using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Models.Infrastructure;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Model.Infrasturcture
{
    public class ContosoMembershipService:MembershipService
    {
        public ContosoMembershipService(IUserRepository userRepository) : base(userRepository)
        {
        }
    }
}
