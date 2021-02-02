using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Tiny.Framework.Registration;

namespace Front
{
    public static class Program
    {
        private static string[] _assemblyNames = { "Front.App", "Front.Services" }; 

        public static async Task Main(string[] args)
        {
            var registrar = GenericHostRegistrar.Create(null, null);
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            builder.Services
                .AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddSingleton<IHtmlSanitizer, HtmlSanitizer>(x =>
                {
                    var sanitizer = new HtmlSanitizer();
                    sanitizer.AllowedAttributes.Add("class");
                    return sanitizer;
                });

            registrar.RegisterWith(builder.Services, _assemblyNames);

            await builder.Build().RunAsync();
        }
    }
}
