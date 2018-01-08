using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChangeWindowsUserPassword.ViewModels
{
    public class ChangePasswordVM
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "New password is not match!")]
        public string ConfirmedPassword { get; set; }
    }
}