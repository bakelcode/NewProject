using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using Microsoft.JSInterop;

namespace NewsProject.Client.Pages
{
    public partial class InvoicesItam
    {
        [Inject]
        public IMainService<Invoicelist> _service { get; set; }
        public List<Invoicelist> _Invouce1{ get; set; } = new List<Invoicelist>();
      
        [Inject]
        public IJSRuntime Js { get; set; }
        protected override async Task OnInitializedAsync()
        {
           
            _Invouce1 = await _service.GetAll("api/Invoiceslist/GetAllInvoicesTemp");
         //   _categories = await _categoryService.GetAll("api/Categories/GetAllCategories");
         

        }

        


      
        public async Task Delete(int id)
        {
            var CurTax = _Invouce1.FirstOrDefault(c => c.InvoicelistID == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _service.DeleteRow($"api/Invoiceslist/Delete/{id}");
                _Invouce1 = await _service.GetAll("api/Invoiceslist/GetAllInvoicesTemp");

            }
        }
    }
}
