using Tiny.Framework.Container;
using Tiny.Framework.Data.Configuration;

namespace Document.API.Configuration
{
    /// <summary>
    /// i configure posted article access scopes.
    /// </summary>
    internal interface IConfigurePostedArticleAccessScope :
        IConfigureContextScope
    {
        /// <summary>
        /// set the host configuration.
        /// </summary>
        /// <param name="host">the host.</param>
        void SetHostConfiguration(IHostConfiguration host);
    }
}