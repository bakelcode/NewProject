using Microsoft.AspNetCore.Components;

namespace NewsProject.Client.Pages
{
    public partial class Index
    {
        [Inject]
        NavigationManager navigationManager { get; set; }

        public Dictionary<string, object> ImageAttribute { get; set; } = new Dictionary<string, object>
    {
        {"src", "/Imgs/FB_IMG_1681892495139.jpg"},
        {"alt", "No Image Found"}
    };
        public string FontColor { get; set; } = "color:blue";
        
        public void GoToCounter()
        {
            navigationManager.NavigateTo("counter");
        }
    }
    
}
