using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BackToOwner.Golf.Web.Models;

namespace BackToOwner.Golf.Web.ViewModels
{
    public class AddBadgeRequest
    {
        public string Command { get; set; }

        public IList<Badge> Badges { get; set; }

        [Required(ErrorMessage = "*")]
        public string NewBadgeNbr { get; set; }
    }
}