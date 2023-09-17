using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class CategoryUpdate
    {
        Category _category = new Category();
        [Inject]
        public IMainService<Category> _service{ get; set; }
        [Parameter]
        public string id { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        protected async override  Task OnInitializedAsync()
        {
            _category = await _service.GetRow($"api/Categories/GetCategory/{id}");
        }
        public async Task Update()
        {
            await _service.UpdateRow(_category, $"/api/Categories/UpdateCategory/{id}");
            _navigationManager.NavigateTo("/categories");
        }

    }
}
