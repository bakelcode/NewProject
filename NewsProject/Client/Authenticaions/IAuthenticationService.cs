using NewsProject.Shared.Dtos.Accounts;
using NewsProject.Shared.Dtos.Administrations;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Authenticaions
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegistrUser(UserregistrationDto userregistration);
        Task<LoginResponseDto> LogIn(LoginDto loginModel);
        Task Logout();
        Task<List<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserByName(string userName);
        Task<ApplicationUser> GetUserByEmail(string userEmail);
        Task<UsersRolesDto> GetUserWithRoles(string userId);
        Task AddUserRole(UsersRolesDto usersRoles);
        Task<RegistrationResponseDto> ChangePassword(ChangePasswordDto changePassword);
        Task ForgotPassword(ForgotPasswordDto forgotPassword);
        Task ResetPassword(ResetPasswordDto resetPassword);
    }
}
