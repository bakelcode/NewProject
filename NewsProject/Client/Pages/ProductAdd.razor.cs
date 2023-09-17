using NewsProject.Shared.Dtos;
using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using NewsProject.Client.Services;

namespace NewsProject.Client.Pages
{
    public partial class ProductAdd
    {
        public ProductDto _product = new ProductDto();
        public List<Category> _categories = new List<Category>();
        public List<Barench> _barench = new List<Barench>();
        [Inject]
        public IMainService<ProductDto> _model { get; set; }
        [Inject]
        public IMainService<Category> _categoryServise { get; set; }
        [Inject]
        public IMainService<Barench> _barenchServise { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        IBrowserFile selectedFile;
        string imgUrl = string.Empty;
        [Parameter]
        public string MyMessages { get; set; } = "";
        protected override async Task OnInitializedAsync()
        {
            _categories = await _categoryServise.GetAll("api/Categories/GetAllCategories");
             _barench = await _barenchServise.GetAll("api/Barenches/GetAllBarenchs");
        }
        public async Task Create()
        {
                _product.Img = selectedFile.Name;

                using (var ms = new MemoryStream())
                {
                    await selectedFile.OpenReadStream().CopyToAsync(ms);
                    _product.NewImg = ms.ToArray();
                    ms.Dispose();
                }

                await _model.AddNewRow(_product, "api/Product/AddProduct");
                _navigationManager.NavigateTo("Productes");
           

           
        }
        private async Task OnFileSelection(InputFileChangeEventArgs e)
        {
            selectedFile = e.File;
            var buffers = new byte[selectedFile.Size];
            await selectedFile.OpenReadStream().ReadAsync(buffers);
            string imageType = selectedFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
            StateHasChanged();
        }
    }
}
