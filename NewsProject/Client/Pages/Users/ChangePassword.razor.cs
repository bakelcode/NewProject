using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Accounts;

namespace NewsProject.Client.Pages.Users
{
    public partial class ChangePassword
    {
        ChangePasswordDto _changePassword = new ChangePasswordDto();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string userName { get; set; }
        public bool ChangePasswordErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public async Task Save()
        {
            ChangePasswordErrors = false;
            _changePassword.UserName = userName;
            var Result = await _authenticationService.ChangePassword(_changePassword);
            if (!Result.IsSuccessful)
            {
                Errors = Result.Errors;
                ChangePasswordErrors = true;
            }
            else
            {
                _authenticationService.Logout();
                _navigationManager.NavigateTo("/");
            }
        }
    }
}
