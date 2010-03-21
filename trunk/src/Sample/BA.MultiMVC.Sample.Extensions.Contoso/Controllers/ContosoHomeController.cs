using System.Web.Mvc;
using BA.MultiMvc.Framework.Core.MultiMVC.Sample.Controllers;
using BA.MultiTenantMVC.Sample.Models.ViewModel;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Controllers
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
