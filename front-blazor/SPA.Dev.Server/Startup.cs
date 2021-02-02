using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SPA.Dev.Server.Middleware;

namespace SPA.Dev.Server
{
    public sealed class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                application
                    .UseDeveloperExceptionPage()
                    .UseWebAssemblyDebugging();
            }

            application
                .UseHttpsRedirection()
                .UseBlazorFrameworkFiles()
                .UseMiddleware<ProxyConfigMiddleware>(Options.Create(BuildProxyRules()))
                .UseRouting()
                .UseStaticFiles()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapFallbackToFile("index.html");
                });
        }

        public RewriteOptions BuildProxyRules()
        {
            var options = new RewriteOptions();
            var rules = new List<ProxyConfigRule>();

            Configuration.Bind("ProxyConfiguration:RewriteRules", rules);

            rules
                .ForEach(rule => options.AddRewrite(rule.Expression, rule.Replacement, true));

            return options;
        }
    }
}
