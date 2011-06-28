using System.Web.Mvc;
using BA.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Models.ViewModel;

namespace BA.MultiMvc.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class ContosoHomeController : HomeController
    {
        public override ActionResult Index()
        {

            var vm = new HomeVM(Context,Resources);
            vm.Message = "Welcome to ASP.NET Mvc on Contoso site!";

// ReSharper disable Asp.NotResolved
            return View(vm);
// ReSharper restore Asp.NotResolved
        }
    }
}
