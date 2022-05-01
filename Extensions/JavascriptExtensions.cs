using Microsoft.JSInterop;

namespace FateCoordinator.Extensions
{
    public static class JavascriptExtensions
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime jsRuntime, string message)
        {
            return await jsRuntime.InvokeAsync<bool>("confirm", message);
        }
    }
}
