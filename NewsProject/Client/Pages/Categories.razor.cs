using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;
using System.Net.Http.Json;

namespace NewsProject.Client.Pages
{
    public partial class Categories
    {
        [Inject]
        public IMainService<Category> _categoryService { get; set; }
        List<Category> _categories { get; set; } = null;
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";
        protected override async Task OnInitializedAsync()
        {
            await Task.Run(GetAllData);
        }
        private async Task GetAllData()
        {

            //System.Threading.Thread.Sleep(5000);
            _categories = new List<Category>();
            _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
        }
        private async Task GetErrors()
        {
                _categories = new List<Category>();
                _categories = await _categoryService.GetAll("api/Categories/GetCategoriesError");
            
        }
        private async Task GetunAuthorized()
        {
            _categories = new List<Category>();
            _categories = await _categoryService.GetAll("api/Categories/GetunAuthorizedError");

        }
        public async Task Delete(int id)
        {
            var CurCategory = _categories.FirstOrDefault(c => c.Id == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _categoryService.DeleteRow($"api/Categories/DeleteCategory/{id}");
                _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
            }
        } 
    }
}
