using System.Web.Mvc;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Controllers;
using BA.MultiTenantMVC.Sample.Models.ViewModel;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class ContosoHomeController : HomeController
    {
        public override ActionResult Index()
        {

            var vm = new HomeVM();
            vm.Message = "Welcome to ASP.NET MVC on Contoso site!";

            return View(vm);
        }
    }
}

