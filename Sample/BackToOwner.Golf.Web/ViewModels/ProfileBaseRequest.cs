using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BA.MultiMvc.Framework;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class ProfileBaseRequest
    {
        public ProfileBaseRequest()
        {
            this.GenderList = new List<SelectListItem>
                                  {
                                       new SelectListItem
                                          {
                                              Selected = true,
                                              Text = "",
                                              Value = ""
                                          },
                                      new SelectListItem
                                          {
                                              Selected = false,
                                              Text = TenantResources.Values["men"],
                                              Value = "Male"
                                          },
                                      new SelectListItem
                                          {
                                              Selected = false,
                                              Text = TenantResources.Values["woman"],
                                              Value = "Female"
                                          }

                                  };

        }

        public List<SelectListItem> GenderList { get; set; }



        [Required(ErrorMessage = "*")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(255, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


       

    }
}