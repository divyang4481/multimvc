using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BA.MultiMvc.Framework;

namespace BackToOwner.Web.Models
{
    public class ActivateIndexRequest
    {
        public ActivateIndexRequest()
        {
            this.BadgeNbr = string.Empty;
        }

        [Required(ErrorMessage = "err_required")]
        public string BadgeNbr { get; set; }
    }
}