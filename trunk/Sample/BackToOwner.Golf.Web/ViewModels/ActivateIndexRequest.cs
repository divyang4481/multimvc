using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using BA.MultiMvc.Framework;
using System.ComponentModel.DataAnnotations;
using BackToOwner.Golf.Web.Models;


namespace BackToOwner.Golf.Web.ViewModels
{
    public class ActivateIndexRequest:ProfileBaseRequest
    {
        public ActivateIndexRequest():base(){}

        [Required(ErrorMessage = "*")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        [Compare("Email")]
        [StringLength(255, MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        public string ConfirmEmail { get; set; }
      

        [Required(ErrorMessage = "*")]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [Compare("Password")]
        [StringLength(50, MinimumLength = 1)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(255, MinimumLength = 1)]
        [EmailsDifferentAttribute]
        [EmailAddress]
        public string Email2 { get; set; }

       
       
    }

    
}