using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;
using System.Net.Http.Json;

namespace NewsProject.Client.Pages
{
    public partial class Barenches
    {
        [Inject]
        public IMainService<Barench> _barenchService { get; set; }
        List<Barench> _barenches { get; set; } = null;
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
            _barenches = new List<Barench>();
            _barenches = await _barenchService.GetAll("api/Barenches/GetAllBarenchs");
        }
        private async Task GetErrors()
        {
            _barenches = new List<Barench>();
            _barenches = await _barenchService.GetAll("api/Barenches/GetBarenchsError");
            
        }
        private async Task GetunAuthorized()
        {
            _barenches = new List<Barench>();
            _barenches = await _barenchService.GetAll("api/Barenches/GetunAuthorizedError");

        }
        public async Task Delete(int id)
        {
            var CurCategory = _barenches.FirstOrDefault(c => c.BarenchID == id);
            var confirmed = await Js.InvokeAsync<bool>("confirm", "Delete row?");

            if (confirmed)
            {
                await _barenchService.DeleteRow($"api/Barenches/DeleteBarenches/{id}");
                _barenches = await _barenchService.GetAll("api/Barenches/GetAllBarenchs");
            }
        } 
    }
}
