using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages.AuthenticationPages
{
    public partial class UserByName
    {
        ApplicationUser _user = new ApplicationUser();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        [Parameter]
        public string userName { get; set; }
        protected async override Task OnInitializedAsync()
        {
            _user = new ApplicationUser();
            _user = await _authenticationService.GetUserByName(userName);
        }
    }
}
