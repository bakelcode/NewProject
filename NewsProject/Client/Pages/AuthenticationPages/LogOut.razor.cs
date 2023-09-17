using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;

namespace NewsProject.Client.Pages.AuthenticationPages
{
    public partial class LogOut
    {
        [Inject]
        public IAuthenticationService _authenticationService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        protected async override Task OnInitializedAsync()
        {

            await _authenticationService.Logout();
            _navigationManager.NavigateTo("/");
        }
    }
}
