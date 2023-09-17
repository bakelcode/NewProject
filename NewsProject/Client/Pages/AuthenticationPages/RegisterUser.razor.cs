using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Dtos.Accounts;

namespace NewsProject.Client.Pages.AuthenticationPages
{
    public partial class RegisterUser
    {
        [Inject]
        public IAuthenticationService _authenticationService { get; set; }
        private UserregistrationDto _userregistration = new UserregistrationDto();
        [Inject]
        public NavigationManager _navigationManager { get; set; }
        public bool RegisterErrors { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public async Task Register()
        {
            RegisterErrors = false;
            var result = await _authenticationService.RegistrUser(_userregistration);
            if (!result.IsSuccessful)
            {
                Errors = result.Errors;
                RegisterErrors = true;
            }
            else
            {
                _navigationManager.NavigateTo("/");
            }
        }
    }
}
