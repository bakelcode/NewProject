using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class CategoryNew
    {
        public Category category = new Category();
        [Inject]
        public IMainService<Category> _model { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";
        public async Task Create()
        {
            try
            {
                await _model.AddNewRow(category, "api/Categories/AddCategory");
                _navigationManager.NavigateTo("/categories");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Category Name Already Exists"))
                    MyMessages = "Category Name Already Exists";
                //MyMessages = ex.Message;
            }
            
        }
    }
}
