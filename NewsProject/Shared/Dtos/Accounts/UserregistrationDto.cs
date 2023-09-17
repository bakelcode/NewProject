using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Accounts
{
    public class UserregistrationDto
    {
        [Required(ErrorMessage = "User name required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Emain required")]
        [EmailAddress(ErrorMessage = "Email format required")]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Do not match")]
        public string ConfirmPassword { get; set; }
    }
}
