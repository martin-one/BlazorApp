using Microsoft.JSInterop;

namespace BlazorApp.Server.Helper
{
    public static class JSRuntimeExtension
    {
        public static async ValueTask ShowToastr(this IJSRuntime jsRuntime, string message, string type)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", type, message);
        }
    }
}
