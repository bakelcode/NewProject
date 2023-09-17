using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NewsProject.Client.Services;
using NewsProject.Shared.Dtos.Administrations;

namespace NewsProject.Client.Pages.AdministrationPages
{
    public partial class RolesList
    {
        private List<RolesDto> _roles = new List<RolesDto>();
        [Inject]
        public IMainService<RolesDto> _roleService { get; set; }
        [Inject]
        public IJSRuntime js { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _roles = new List<RolesDto>();
            _roles = await _roleService.GetAll("api/Administrations/GetAllRoles");
        }
        public async Task Delete(string id)
        {
            var _curRole= _roles.FirstOrDefault(r=> r.Id==id);
            var confirmed = await js.InvokeAsync<bool>("confirm", "Delete row?");
            if (confirmed)
            {
                await _roleService.DeleteRow($"api/Administrations/DeleteRole?RoleId={id}");
                _roles = await _roleService.GetAll("api/Administrations/GetAllRoles");
            }
        }
    }
}
