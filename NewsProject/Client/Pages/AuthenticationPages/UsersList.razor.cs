using Microsoft.AspNetCore.Components;
using NewsProject.Client.Authenticaions;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages.AuthenticationPages
{
    public partial class UsersList
    {
        List<ApplicationUser> _users { get; set; } = new List<ApplicationUser>();
        [Inject]
        IAuthenticationService _authenticationService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _users = new List<ApplicationUser>();
            _users = await _authenticationService.GetAllUsers();
        }
    }
}
