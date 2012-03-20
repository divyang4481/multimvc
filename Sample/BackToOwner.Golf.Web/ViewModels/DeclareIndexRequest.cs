using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class DeclareIndexRequest
    {
        public DeclareIndexRequest()
        {
            this.CountryCodeList = ViewModelsFactory.CreateCountryList();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [StringLength(100, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public List<SelectListItem> CountryCodeList { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(2, MinimumLength = 1)]
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(12, MinimumLength = 6)]
        [Digit(ErrorMessage="*")]
        public string PhoneNumber { get; set; }

       

    }
}