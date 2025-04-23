using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TechStore.Blazor.Apis;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddHttpClient<ICategoryApi, CategoryApi>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5016/");
            });
            await builder.Build().RunAsync();
        }
    }
}
