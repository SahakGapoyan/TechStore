using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TechStore.Blazor.Apis;
using TechStore.Blazor.Configuration;
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
            builder.Services.AddOptions<ApiSettings>().BindConfiguration("ApiSettings");

            builder.Services.AddMudServices();

            builder.Services.AddScoped<IBrandApi, BrandApi>();
            builder.Services.AddScoped<ICategoryApi, CategoryApi>();
            builder.Services.AddScoped<ISmartPhoneApi, SmartPhoneApi>();
            builder.Services.AddScoped<IRamApi, RamApi>();
            builder.Services.AddScoped<IColorApi, ColorApi>();
            builder.Services.AddScoped<IMemoryApi, MemoryApi>();
            builder.Services.AddScoped<IOSApi, OSApi>();
            builder.Services.AddScoped<ILaptopApi, LaptopApi>();
            builder.Services.AddScoped<IModelApi, ModelApi>();
            builder.Services.AddScoped<ITvApi, TvApi>();

            await builder.Build().RunAsync();
        }
    }
}
