using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class ActivateMobileRequest
    {

        public ActivateMobileRequest()
        {
            this.CountryCodeList = ViewModelsFactory.CreateCountryList();
        }


        public List<SelectListItem> CountryCodeList { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(2, MinimumLength = 1)]
        public string CountryCode { get; set; }
        
        [Required(ErrorMessage = "*")]
        [StringLength(12, MinimumLength = 6)]
        [Digit(ErrorMessage = "*")]
        public string PhoneNumber{ get; set; }

        [StringLength(2, MinimumLength = 1)]
        public string CountryCode2 { get; set; }

        [StringLength(12, MinimumLength = 6)]
        [Digit(ErrorMessage = "*")]
        public string PhoneNumber2 { get; set; }


        [Required(ErrorMessage = "*")]
        public bool AcceptTerms { get; set; }
    }
}