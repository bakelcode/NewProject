using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Accounts;

namespace NewsProject.Client.Pages.Users
{
    public partial class ResetPassword
    {
        ResetPasswordDto _reset = new ResetPasswordDto();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        [SupplyParameterFromQuery(Name = "email")]
        public string Email { get; set; }
        [Parameter]
        [SupplyParameterFromQuery(Name = "token")]
        public string Token { get; set; }
        public async Task reset()
        {
            _reset.Email = Email;
            _reset.Token = Token;
            await _authenticationService.ResetPassword(_reset);
            _navigationManager.NavigateTo("/login");
        }
    }
}
