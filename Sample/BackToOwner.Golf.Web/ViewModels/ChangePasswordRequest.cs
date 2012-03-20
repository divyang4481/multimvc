using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class ChangePasswordRequest
    {

        public string ConfirmMessage { get; set; }

        [Required(ErrorMessage = "*")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 5)]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "*")]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}