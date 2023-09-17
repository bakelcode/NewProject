using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Dtos.Administrations
{
    public class UsersRolesDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<SelectedRolesDto> Roles { get; set; }
    }
}
