using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using Microsoft.JSInterop;

namespace NewsProject.Client.Pages
{
    public partial class Productes
    {
        [Inject]
        public IMainService<Product> _service { get; set; }
        public List<Product> _product { get; set; } = new List<Product>();
        private List<Category> _categories = new List<Category>();
     //   private List<Barench> barenches = new List<Barench>();
        [Inject]
        IMainService<Category> _categoryService { get; set; }
       // [Inject]
      //  IMainService<Barench> _barenchesService { get; set;}
        [Parameter]
        public int CatID { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        protected override async Task OnInitializedAsync()
        {
           
            _product = await _service.GetAll("api/Product/GetAllProduct");
            _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
          //  barenches = await _barenchesService.GetAll("api/Barenches/GetAllBarenchs");

        }

        


        private async Task GetProductByCategoryId(int value)
        {
            CatID = value;
            _product = new List<Product>();
            if (CatID == 0)
            {
                _product = await _service.GetAll("api/Product/GetAllProduct");
            }
            else
            {
                _product = await _service.GetAll($"api/Product/GetAllProductListByCategory?id={CatID}");
            }

        }
        public async Task Delete(int id)
        {
            var CurTax = _product.FirstOrDefault(c => c.ProductID == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _service.DeleteRow($"api/Product/Delete/{id}");
                _product = await _service.GetAll("api/Product/GetAllProduct");

            }
        }
    }
}
