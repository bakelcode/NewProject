using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Administrations
{
    public class AddRoleResponseDto
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
