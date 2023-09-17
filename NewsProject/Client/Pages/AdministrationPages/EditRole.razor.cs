using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Dtos.Administrations;

namespace NewsProject.Client.Pages.AdministrationPages
{
    public partial class EditRole
    {
        RolesDto _roles = new RolesDto();
        [Inject]
        public IMainService<RolesDto> _roleService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _roles = await _roleService.GetRow($"api/Administrations/GetRoleById/{id}");
        }
        public async Task Update()
        {
            await _roleService.UpdateRow(_roles, $"api/Administrations/EditRole?Currole={id}");
            _navigationManager.NavigateTo("/roleslist");
        }
    }
}
