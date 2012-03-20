using System.Collections.Generic;
using System.Web.Mvc;

namespace BackToOwner.Golf.Web.ViewModels
{
    public static class ViewModelsFactory
    {
        public static List<SelectListItem> CreateCountryList()
        {
            return new List<SelectListItem>
                       {
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Belgium",
                                   Value = "32"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "France",
                                   Value = "31"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Nederland",
                                   Value = "33"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Greece",
                                   Value = "30"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Spain",
                                   Value = "34"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Italy",
                                   Value = "39"
                               }, 
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "United Kingdom",
                                   Value = "44"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Denmark",
                                   Value = "45"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Switzerland",
                                   Value = "41"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Austria",
                                   Value = "43"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Denmark",
                                   Value = "45"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Switzerland",
                                   Value = "41"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Austria",
                                   Value = "43"
                               },
                           new SelectListItem
                               {
                                   Selected = false,
                                   Text = "Germany",
                                   Value = "49"
                               }

                       };
        }
    }
}