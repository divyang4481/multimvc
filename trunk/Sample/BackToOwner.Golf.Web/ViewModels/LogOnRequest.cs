using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class LogOnRequest
    {
        [Required(ErrorMessage ="*")]
        public string LabelNbr { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }

        public string ConfirmationMessage { get; set; }
    }
}