using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using Microsoft.JSInterop;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class InvoicesAdd
    {


        // public InvoiceTemp invoiceTemps = new InvoiceTemp();
        private List<Supplier> _suppliers = new List<Supplier>();
        private List<InvoiceTemp> _invotemp = new List<InvoiceTemp>();
        public Invoice _invoice = new Invoice();
        [Inject]
        public IMainService<Invoice> _serviceAdd { get; set; }
        [Inject]
        public IMainService<Supplier> _servicesp { get; set; }
      
        [Inject]
        public IMainService<InvoiceTemp> _serviceInvTamp { get; set; }
    
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";
        [Parameter]
        public decimal? Discount { get; set; } = 0;
        
        //[Inject]
        //public IJSRuntime Js { get; set; }

        // public DateOnly date1 = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        protected override async Task OnInitializedAsync()
        {

            _suppliers = await _servicesp.GetAll("api/Supplier/GetAllSupplieres");
            _invotemp = await _serviceInvTamp.GetAll("api/InvoicesTemp/GetAllInvoicesTemp");
            totalof();

        }
        //private async Task Update()
        //{
           
        //}
        public async Task Create()
        {
            try
            {

                totalof();


                    await _serviceAdd.AddNewRow(_invoice, "api/Invoices/AddInvvv");
                    _navigationManager.NavigateTo("/Invoices");

            }//InvoicesAdd  _navigationManager.NavigateTo("/InvoicesAdd");
            catch (Exception ex)
            {
                if (ex.Message.Contains("Invoices Name Already Exists"))
                    MyMessages = "Invoices Name Already Exists";
                //MyMessages = ex.Message;
            }

        }
        public  void totalof()
        {
            _invoice.Date = DateTime.Now;
            var total = _invotemp.Sum(x => x.Total);
            
            _invoice.Total = total;
            _invoice.Discontafter = total  ;
            


        }
        private void DiscountChanged(decimal? value )
        {
            _invoice.Discont = (decimal) value;

            CalculateToatl();
        }
        


        protected override void OnParametersSet()
        {
           
            CalculateToatl();
            base.OnParametersSet();
        }



      
        private void CalculateToatl()
        {
            var total = _invotemp.Sum(x => x.Total);

            _invoice.Total = total;
            _invoice.Discontafter = total;
            _invoice.Discontafter = _invoice.Total - _invoice.Discont;

        }




    }
}
