using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class EditOwnerRequest:ProfileBaseRequest
    {
        public EditOwnerRequest():base()
        {
            this.CountryCodeList = ViewModelsFactory.CreateCountryList();
        }

        public List<SelectListItem> CountryCodeList { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(255, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(255, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(2, MinimumLength = 1)]
        public string CountryCode { get; set; }
        
        [Required(ErrorMessage = "*")]
        [StringLength(12, MinimumLength = 1)]
        public string PhoneNumber{ get; set; }

        [StringLength(2, MinimumLength = 1)]
        public string CountryCode2 { get; set; }

        [StringLength(12, MinimumLength = 1)]
        public string PhoneNumber2 { get; set; }

        public string ConfirmationMessage { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(255, MinimumLength = 5)]
        [EmailsDifferentAttribute(ErrorMessage = "*")]
        public string Email2 { get; set; }

        public class EmailsDifferentAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    var model = (EditOwnerRequest)validationContext.ObjectInstance;

                    if (string.Compare((string)value, model.Email, true) == 0)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
                return ValidationResult.Success;
            }
        }
    }
}