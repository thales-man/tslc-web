using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tiny.Framework.Utility;

namespace SPA.Dev.Server.Middleware
{
    public class ProxyConfigMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly RewriteOptions _options;

        private readonly IFileProvider _fileProvider;

        private readonly ILogger _logger;

        private readonly HttpClient _client = new HttpClient();

        public ProxyConfigMiddleware(
            RequestDelegate next,
            IWebHostEnvironment hostingEnvironment,
            ILogger<ProxyConfigMiddleware> logger,
            IOptions<RewriteOptions> options)
        {
            It.IsNull(next)
                .AsGuard<ArgumentNullException>(nameof(next));
            It.IsNull(options)
                .AsGuard<ArgumentNullException>(nameof(options));

            _next = next;
            _options = options.Value;
            _fileProvider = _options.StaticFileProvider ?? hostingEnvironment.WebRootFileProvider;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            It.IsNull(context)
                .AsGuard<ArgumentNullException>(nameof(context));

            var rewriteContext = new RewriteContext
            {
                HttpContext = context,
                StaticFileProvider = _fileProvider,
                Logger = _logger,
                Result = RuleResult.ContinueRules
            };

            foreach (var rule in _options.Rules)
            {
                rule.ApplyRule(rewriteContext);

                if (rewriteContext.Result == RuleResult.SkipRemainingRules)
                {
                    var contextBody = context.Response.Body;

                    var result = await _client.GetStreamAsync(context.Request.GetEncodedUrl());

                    await result.CopyToAsync(contextBody);

                    return;
                }
            }

            await _next(context);
        }
    }
}