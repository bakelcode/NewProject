using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Accounts
{
    public class ResetPasswordDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfimPassword { get; set; }
        public string Token { get; set; }
    }
}
