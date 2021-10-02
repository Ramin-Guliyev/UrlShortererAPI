using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Threading.Tasks;
using URLShortererWebUI.DataAccess;

namespace URLShortererWebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddRefitClient<IUrlDataAccess>().ConfigureHttpClient(x => {
                x.BaseAddress = new Uri("https://localhost:5001");
            });
            await builder.Build().RunAsync();
        }
    }
}
