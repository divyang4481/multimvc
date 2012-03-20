using System.ComponentModel.DataAnnotations;

namespace BackToOwner.Golf.Web.Models
{
    public class HomeIndexRequest
    {
        public HomeIndexRequest()
        {
            this.BadgeNbr = string.Empty;
        }

        [Required(ErrorMessage = "*")]
        public string BadgeNbr { get; set; }
    }
}