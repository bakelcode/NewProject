using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Accounts;

namespace NewsProject.Client.Pages.Users
{
    public partial class ForgotPassword
    {
        ForgotPasswordDto _forgot = new ForgotPasswordDto();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        public async Task send()
        {
            _forgot.WebLink = _navigationManager.BaseUri + "resetpassword";
            _authenticationService.ForgotPassword(_forgot);
        }
    }
}
