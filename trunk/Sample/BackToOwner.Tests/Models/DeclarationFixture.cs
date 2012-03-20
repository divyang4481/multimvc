using BackToOwner.Golf.Web.Models;
using BackToOwner.Golf.Web.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackToOwner.Golf.Tests.Models
{
        [TestClass]
        public class GivenDeclaration:Specification
        {
            protected Declaration Declaration;

            public override void Given()
            {
                base.Given();
                this.Declaration = DomainStubFactory.CreateDeclaration();
            }   
        }
    
}
