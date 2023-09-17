using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace NewsProject.Client.Services
{
    public class MainService<T> : IMainService<T> where T : class
    {
        public HttpClient _httpClient;
        public NavigationManager _navigationManager;
        public MainService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }



        public async Task<List<T>> GetAll(string ApiName)
        {
            var Respons = await _httpClient.GetAsync(ApiName);
            if (!Respons.IsSuccessStatusCode)
            {
                if (Respons.StatusCode == HttpStatusCode.NotFound)
                {
                    _navigationManager.NavigateTo("/404");
                }else if(Respons.StatusCode == HttpStatusCode.Unauthorized)
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
            return await _httpClient.GetFromJsonAsync<List<T>>(ApiName);
        }
        public async Task<T> GetRow(string ApiName)
        {
            var Respons = await _httpClient.GetAsync(ApiName);
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
            return await _httpClient.GetFromJsonAsync<T>(ApiName);
        }
        public async Task<T> AddNewRow(T entity, string ApiName)
        {
            var result = await _httpClient.PostAsJsonAsync<T>(ApiName, entity);
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
            return null;
        }
        public async Task<T> UpdateRow(T entity, string ApiName)
        {
            var result = await _httpClient.PutAsJsonAsync<T>(ApiName, entity);
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
            return null;
        }

        public async Task DeleteRow(string ApiName)
        {
            var result = await _httpClient.DeleteAsync(ApiName);
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
