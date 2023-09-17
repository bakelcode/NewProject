using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Accounts
{
    public class LoginResponseDto
    {
        public bool IsLogInSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
    }
}
