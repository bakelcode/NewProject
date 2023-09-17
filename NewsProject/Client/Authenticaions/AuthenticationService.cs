using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using NewsProject.Shared.Dtos.Accounts;
using NewsProject.Shared.Dtos.Administrations;
using NewsProject.Shared.Models;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace NewsProject.Client.Authenticaions
{
    public class AuthenticationService : IAuthenticationService
    {
        public HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly AuthenticationStateProvider _stateProvider;
        private readonly ILocalStorageService _localStorage;
        public NavigationManager _navigationManager;
        public AuthenticationService(HttpClient httpClient, AuthenticationStateProvider stateProvider, ILocalStorageService localStorage, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _stateProvider = stateProvider;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }

        public async Task<RegistrationResponseDto> RegistrUser(UserregistrationDto userregistration)
        {
            var result = await _httpClient.PostAsJsonAsync<UserregistrationDto>("api/Accounts/RegisterUser", userregistration);
            if (!result.IsSuccessStatusCode)
            {
                var resultMsg = await result.Content.ReadAsStringAsync();
                var msg = JsonSerializer.Deserialize<RegistrationResponseDto>(resultMsg, _options);
                return msg;
            }
            return new RegistrationResponseDto { IsSuccessful = true};
        }

        public async Task<LoginResponseDto> LogIn(LoginDto loginModel)
        {
            var result = await _httpClient.PostAsJsonAsync<LoginDto>("api/Accounts/Login", loginModel);
            var resultMsg = await result.Content.ReadAsStringAsync();
            var msg = JsonSerializer.Deserialize<LoginResponseDto>(resultMsg, _options);
            if (!result.IsSuccessStatusCode)
            {
                return msg;
            }
            await _localStorage.SetItemAsync("AppToken", msg.Token);
            ((AppAuthenticationStateProvider)_stateProvider).NotifyUserAuthentication(msg.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", msg.Token);
            if (loginModel.RememberMe)
            {
                await _localStorage.SetItemAsync("IsPersistentToken", "Ispersistent");
            }
            else
            {
                await _localStorage.RemoveItemAsync("IsPersistentToken");
            }
            return new LoginResponseDto { IsLogInSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("AppToken");
            await _localStorage.RemoveItemAsync("IsPersistentToken");
            ((AppAuthenticationStateProvider)_stateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            var Respons = await _httpClient.GetAsync("api/Users/GetAllUsers");
            if (!Respons.IsSuccessStatusCode)
            {
                if (Respons.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (Respons.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (Respons.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await Respons.Content.ReadAsStringAsync();
                throw new Exception(Respons.ReasonPhrase + "_" + Msg);
            }
            return await _httpClient.GetFromJsonAsync<List<ApplicationUser>>("api/Users/GetAllUsers");
        }
        public async Task<UsersRolesDto> GetUserWithRoles(string userId)
        {
            var Respons = await _httpClient.GetAsync($"api/Users/GetUserWithRoles/{userId}");
            if (!Respons.IsSuccessStatusCode)
            {
                if (Respons.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (Respons.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (Respons.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await Respons.Content.ReadAsStringAsync();
                throw new Exception(Respons.ReasonPhrase + "_" + Msg);
            }
            return await _httpClient.GetFromJsonAsync<UsersRolesDto>($"api/Users/GetUserWithRoles/{userId}");
        }
        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            var Respons = await _httpClient.GetAsync($"api/Users/GetUserByName?userName={userName}");
            if (!Respons.IsSuccessStatusCode)
            {
                if (Respons.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (Respons.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (Respons.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await Respons.Content.ReadAsStringAsync();
                throw new Exception(Respons.ReasonPhrase + "_" + Msg);
            }
            return await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/Users/GetUserByName?userName={userName}");
        }

        public async Task<ApplicationUser> GetUserByEmail(string userEmail)
        {
            var Respons = await _httpClient.GetAsync($"api/Users/GetUserByEmail?userEmail={userEmail}");
            if (!Respons.IsSuccessStatusCode)
            {
                if (Respons.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (Respons.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (Respons.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await Respons.Content.ReadAsStringAsync();
                throw new Exception(Respons.ReasonPhrase + "_" + Msg);
            }
            return await _httpClient.GetFromJsonAsync<ApplicationUser>($"api/Users/GetUserByEmail?userEmail={userEmail}");
        }

        public async Task AddUserRole(UsersRolesDto usersRoles)
        {
            var result = await _httpClient.PostAsJsonAsync<UsersRolesDto>($"api/Users/AddUserRoles", usersRoles);
            if (!result.IsSuccessStatusCode)
            {
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (result.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await result.Content.ReadAsStringAsync();
                throw new Exception(result.ReasonPhrase + "_" + Msg);
            }
        }

        public async Task<RegistrationResponseDto> ChangePassword(ChangePasswordDto changePassword)
        {
            var Respons = await _httpClient.PutAsJsonAsync<ChangePasswordDto>($"api/Users/ChangePassword?changePassword={changePassword.UserName}", changePassword);
            if (!Respons.IsSuccessStatusCode)
            {
                var resultMsg = await Respons.Content.ReadAsStringAsync();
                var msg = JsonSerializer.Deserialize<RegistrationResponseDto>(resultMsg, _options);
                return msg;
            }
            return new RegistrationResponseDto { IsSuccessful = true };
        }

        public async Task ForgotPassword(ForgotPasswordDto forgotPassword)
        {
            var result = await _httpClient.PostAsJsonAsync<ForgotPasswordDto>($"api/users/ForgotPassword", forgotPassword);
            if (!result.IsSuccessStatusCode)
            {
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (result.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await result.Content.ReadAsStringAsync();
                throw new Exception(result.ReasonPhrase + "_" + Msg);
            }
        }

        public async Task ResetPassword(ResetPasswordDto resetPassword)
        {
            var result = await _httpClient.PostAsJsonAsync<ResetPasswordDto>($"api/users/ResetPassword", resetPassword); 
            if (!result.IsSuccessStatusCode)
            {
                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }
                else if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else if (result.StatusCode == HttpStatusCode.Forbidden)
                {
                    _navigationManager.NavigateTo("/Unauthorized");
                }
                else
                {
                    _navigationManager.NavigateTo("/500");
                }
                var Msg = await result.Content.ReadAsStringAsync();
                throw new Exception(result.ReasonPhrase + "_" + Msg);
            }
        }
    }
}
