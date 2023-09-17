using Microsoft.AspNetCore.Components;
using NewsProject.Client.Services;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class BarenchUpdate
    {
        Barench _barench = new Barench();
        [Inject]
        public IMainService<Barench> _service{ get; set; }
        [Parameter]
        public string id { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        protected async override  Task OnInitializedAsync()
        {
            _barench = await _service.GetRow($"api/Barenches/GetBarench/{id}");
        }
        public async Task Update()
        {
            await _service.UpdateRow(_barench, $"/api/Barenches/UpdateBarenches/{id}");
            _navigationManager.NavigateTo("/barenches");
        }

    }
}
