using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace _10.JsInterop.Pages
{
    public partial class Index
    {
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        private async Task Fireworks()
        {
            ArgumentNullException.ThrowIfNull(JSRuntime);
            await JSRuntime.InvokeVoidAsync("Fireworks");
        }
    }
}
