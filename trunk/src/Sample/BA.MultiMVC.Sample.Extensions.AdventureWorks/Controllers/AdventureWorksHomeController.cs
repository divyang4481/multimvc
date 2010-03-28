using System.Web.Mvc;
using BA.MultiMvc.Framework.Core.MultiMvc.Sample.Controllers;
using BA.MultiMvc.Sample.Models.ViewModel;
using BA.MultiMvc.Sample.Extensions.AdventureWorks.ViewModel;

namespace BA.MultiMvc.Framework.Core.MultiMvc.Sample.Extensions.Contoso.Controllers
{
    [HandleError]
    public class AdventureworksHomeController : HomeController
    {
        protected override HomeVM HomeView
        {
            get
            {
                var view = new IndexViewModel();
                view.Message = "Welcome to ASP.NET Mvc on Adventureworks site!";
                return view;
            }
        }
    }
}

