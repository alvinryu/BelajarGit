using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Invalid")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Invalid")]
        public string NewPassword { get; set; }

        [Compare("NewPassword"), Required]
        public string ConfirmPassword { get; set; }
    }
}
