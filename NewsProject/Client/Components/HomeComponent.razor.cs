using Microsoft.AspNetCore.Components;

namespace NewsProject.Client.Components
{
    public partial class HomeComponent
    {
        [Parameter]
        public string Name { get; set; } = "BAKEL";
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> ImageAttribute { get; set; }

        [CascadingParameter]
        public string Style { get; set; }
    }
}
