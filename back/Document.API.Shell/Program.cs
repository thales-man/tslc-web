// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Tiny.Framework.Web.Shell;

namespace Document.API.Shell
{
    /// <summary>
    /// the program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// the program entry point, main.
        /// </summary>
        /// <param name="args">the commandline arguments.</param>
        public static void Main(string[] args)
        {
            WebShell.BuildWebHost<Startup>(args).Run();
        }

        /// <summary>
        /// the inherited start up class.
        /// </summary>
        public sealed class Startup : ShellStartup
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Startup"/> class.
            /// </summary>
            /// <param name="configuration">the configuration.</param>
            /// <param name="environment">the environment.</param>
            public Startup(IConfiguration configuration, IHostEnvironment environment)
                : base(configuration, environment)
            {
            }
        }
    }
}
