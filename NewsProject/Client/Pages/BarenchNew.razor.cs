using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class BarenchNew
    {
        public Barench barench = new Barench();
        [Inject]
        public IMainService<Barench> _model { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public string MyMessages { get; set; } = "";
        public async Task Create()
        {
            try
            {
                await _model.AddNewRow(barench, "api/Barenches/AddBarench");
                _navigationManager.NavigateTo("/barenches");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Barench Name Already Exists"))
                    MyMessages = "Barench Name Already Exists";
                //MyMessages = ex.Message;
            }
            
        }
    }
}
