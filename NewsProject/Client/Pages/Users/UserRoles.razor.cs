using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Administrations;

namespace NewsProject.Client.Pages.Users
{
    public partial class UserRoles
    {
        UsersRolesDto _userRoles = new UsersRolesDto();
        List<SelectedRolesDto> _rolesList = new List<SelectedRolesDto>();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string UserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _userRoles = new UsersRolesDto();
            _userRoles = await _authenticationService.GetUserWithRoles(UserId);
        }
        private async Task Save()
        {
            await _authenticationService.AddUserRole(_userRoles);
            _navigationManager.NavigateTo("/usersList");
        }
    }
}
