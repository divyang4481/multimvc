using System.Web.Mvc;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Models.ViewModel;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class ContosoHomeController : HomeController
    {
        public override ActionResult Index()
        {

            var vm = new HomeVM();
            vm.Message = "Welcome to ASP.NET Mvc on Contoso site!";

            return View(vm);
        }
    }
}
