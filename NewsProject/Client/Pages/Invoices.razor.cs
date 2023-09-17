
using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using Microsoft.JSInterop;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class Invoices
    {
        [Inject]
        public IMainService<Invoice> _service { get; set; }
        public List<Invoice> _invouce { get; set; } = new List<Invoice>();
      
        [Inject]
        public IJSRuntime Js { get; set; }
        protected override async Task OnInitializedAsync()
        {
           
            _invouce = await _service.GetAll("api/Invoices/GetAllInvoices");
       
         

        }

        


      
        public async Task Delete(int id)
        {
            var CurTax = _invouce.FirstOrDefault(c => c.InvoiceId == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _service.DeleteRow($"api/Invoices/Delete/{id}");
                _invouce = await _service.GetAll("api/Invoices/GetAllInvoices");

            }
        }
    }
}
