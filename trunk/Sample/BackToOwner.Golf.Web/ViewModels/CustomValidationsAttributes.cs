using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using BA.MultiMvc.Framework;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class EmailsDifferentAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var model = (ActivateIndexRequest)validationContext.ObjectInstance;

                if (string.Compare((string)value, model.Email, true) == 0)
                {
                    return new ValidationResult(TenantResources.Values["err_email_notsame"]);
                }
            }
            return ValidationResult.Success;
        }
    }

    public class EmailAddressAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"

                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"

                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"

                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"

                        + @"[a-zA-Z]{2,}))$";

                if (!Regex.IsMatch(value.ToString(), patternStrict))
                {
                    return new ValidationResult(TenantResources.Values["err_invalid_email"]);
                }


            }
            return ValidationResult.Success;
        }
    }

    public class DigitAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value==null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            
            int result;
            if (int.TryParse(value.ToString(),out result))
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult(ErrorMessage);
            
        }
    }

    public class MultiRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(TenantResources.Values["err_required"]);
            
        }
    }
}