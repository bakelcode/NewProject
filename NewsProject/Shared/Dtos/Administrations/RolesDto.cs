using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Administrations
{
    public class RolesDto
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Role Name Required")]
        public string Name { get; set; }
    }
}
