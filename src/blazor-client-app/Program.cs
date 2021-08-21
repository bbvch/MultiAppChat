namespace blazor_client_app
{
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    using blazor_client_app.Chat;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
            });

            builder.Services.AddScoped<ChatService>();

            await builder.Build().RunAsync();
        }
    }
}
