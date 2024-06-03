using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Components
{
    public partial class WasmPageBase : ComponentBase
    {
        
        string componentTypeDescription = "Page";

        [Inject]
        public ILogger<WasmPageBase> Logger { get; set; }

        protected override void OnInitialized()
        {

            Logger.LogInformation($"{componentTypeDescription} Initialized");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Logger.LogInformation($"{componentTypeDescription} rendered first render.");
            }
            else
            {
                Logger.LogInformation($"{componentTypeDescription} rendered");
            }
        }
    }
}
