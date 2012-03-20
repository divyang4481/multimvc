using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class SendPasswordRequest
    {
        [Required(ErrorMessage = "err_required")]
        public string LabelNbr { get; set; }
        
        public string ConfirmationMessage { get; set; }
    }
}