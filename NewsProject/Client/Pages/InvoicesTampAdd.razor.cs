using NewsProject.Shared.Models;
using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using Microsoft.JSInterop;

namespace NewsProject.Client.Pages
{
    public partial class InvoicesTampAdd
    {
         
         List<Product> products = new List<Product>();
         List<Barench> barenches  =new List<Barench>();
         InvoiceTemp invoiceTemps = new InvoiceTemp();
        public Invoice bakinv = new Invoice();
        List<InvoiceTemp> _invotemp =new List<InvoiceTemp>();   
        public List<Category> categories = new List<Category>();
         
        [Inject]
        public IMainService<Category> _serviceCat { get; set; }
        [Inject]
        public IMainService<Product> _servicePro { get; set; }
        [Inject]
        public IMainService<InvoiceTemp> _serviceInvTamp { get; set; }
        [Inject]
        public IMainService<Barench> _serviceBare { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";
        [Inject]
        public IJSRuntime Js { get; set; }
        [Parameter]
        public int CatId { get; set; }
        [Parameter]
        public int ProId { get; set; }
        [Parameter]
        public decimal? Totall { get; set; }
        [Parameter]

        public decimal? Totallafter { get; set; }
        [Parameter]
        public decimal? Discount { get; set; } = 12;


        protected Product bak { get; set; } = new Product();
        // public DateOnly date1 = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
     
        protected override async Task OnInitializedAsync()
        {
            
            categories = await _serviceCat.GetAll("api/Categories/GetAllCategories");
            barenches = await _serviceBare.GetAll("api/Barenches/GetAllBarenchs");
            _invotemp = await _serviceInvTamp.GetAll("api/InvoicesTemp/GetAllInvoicesTemp");
            products = await _servicePro.GetAll("api/Product/GetAllProduct");
            //    suppliers = await _servicesp.GetAll("api");
          // CalculateToatl();

        }
       // public async Task Create()
        public async Task Create()
        { 
            try
            {
                
                //   invoiceTemps.CategoryId = CatId ;
                // invoiceTemps.ProductID =ProId ;
                if (invoiceTemps.Quntity > 0 && invoiceTemps.ProductID != null)
                {
                   
                    await _serviceInvTamp.AddNewRow(invoiceTemps, "api/InvoicesTemp/AddInvoiceTemp");
                     

                    invoiceTemps = new InvoiceTemp();
                    _invotemp = await _serviceInvTamp.GetAll("api/InvoicesTemp/GetAllInvoicesTemp");
                   
                }

            }//InvoicesTemp
            catch (Exception ex)
            {
                if (ex.Message.Contains("InvoicesTemp Name Already Exists"))
                    MyMessages = "InvoicesTemp Name Already Exists";
                //MyMessages = ex.Message;
            }

        }
        private async Task GetNewsByCategoryId(int value)
        {
            invoiceTemps.BarenchID = 1;
          
           CatId = value;
                        
            invoiceTemps.CategoryId = CatId;
            products = new List<Product>();
            if (CatId == 0)
            {
                products = await _servicePro.GetAll("api/Product/GetAllProduct");
            }
            else
            {
                products = await _servicePro.GetAll($"api/Product/GetAllProductByCategory?id={CatId}");
            }

        }
       // GetProduct
        private async Task GetInvoiceItampProductById(int value) 
        {
            ProId = value;
          
           
            invoiceTemps.ProductID = ProId;
            if (ProId != 0)
            {
                bak = await _servicePro.GetRow($"api/Product/GetProduct/{ProId}");
                bak.CreatDate = DateTime.Now.AddYears(-1);


                invoiceTemps.Price = bak.Price;
                invoiceTemps.Quntity = 1;
               
            }

         
        }
        private void CalculateToatl()
        {  
            Totall = _invotemp.Sum(x => x.Total);
            Totallafter = Totall - bakinv.Discont;
            bakinv.Discont = 20;

        }

        public async Task Delete(int id)
        {
            var CurCategory = _invotemp.FirstOrDefault(c => c.InvoiceTempID == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _serviceInvTamp.DeleteRow($"api/InvoicesTemp/DeleteInvoiceTemp/{id}");
                _invotemp = await _serviceInvTamp.GetAll("api/InvoicesTemp/GetAllInvoicesTemp");
            //    CalculateToatl();
            }
        }

    }
}
