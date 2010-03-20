using System.Web.Mvc;
using BA.MultiMVC.Framework.Core.MultiMVC.Sample.Controllers;
using BA.MultiTenantMVC.Sample.Models.ViewModel;
using BA.MultiMVC.Sample.Extensions.AdventureWorks.ViewModel;

namespace BA.MultiMVC.Framework.Core.MultiMVC.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class AdventureworksHomeController : HomeController
    {
        protected override HomeVM HomeView
        {
            get
            {
                var view = new IndexViewModel();
                view.Message = "Welcome to ASP.NET MVC on Adventureworks site!";
                return view;
            }
        }
    }
}

