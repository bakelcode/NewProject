using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Accounts
{
    public class ChangePasswordDto
    {
        public string UserName { get; set; }
        [Required(ErrorMessage ="Current Password Required")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage = "New Password Required")]
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ComfirmPassword { get; set; }
    }
}
