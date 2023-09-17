using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Dtos.Administrations;

namespace NewsProject.Client.Pages.AdministrationPages
{
    public partial class AddRole
    {
        public RolesDto _roles = new RolesDto();
        [Inject]
        public IMainService<RolesDto> _roleService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }

        public async Task Create()
        {
            await _roleService.AddNewRow(_roles, "api/Administrations/AddRole");
            _navigationManager.NavigateTo("/roleslist");
        }
    }
}
