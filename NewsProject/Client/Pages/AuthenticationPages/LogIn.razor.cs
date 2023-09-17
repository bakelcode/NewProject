using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Accounts;

namespace NewsProject.Client.Pages.AuthenticationPages
{
    public partial class LogIn
    {
        private LoginDto _login = new LoginDto();
        [Inject]
        public IAuthenticationService _authenticationService { get; set; }
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public bool LoginErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }
        [Parameter]
        public bool RememberMe { get; set; } = false;
        public async Task LogInUser()
        {
            LoginErrors = false;
            _login.RememberMe = RememberMe;
            var result = await _authenticationService.LogIn(_login);
            if (!result.IsLogInSuccessful)
            {
                Errors = result.Errors;
                LoginErrors = true;
            }
            else
            {
                _navigationManager.NavigateTo("/");
            }
        }
        private void CheckBoxChanged()
        {
            RememberMe = !RememberMe;
        }
    }
}
