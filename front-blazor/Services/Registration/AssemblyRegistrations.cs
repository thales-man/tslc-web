// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using Front.Services.Services;
using Front.Services.ViewModels;
using Tiny.Framework.Registration.Attributes;

// services
[assembly: InternalRegistration(typeof(IArticleProvider), typeof(ArticleProvider), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(IMenuProvider), typeof(MenuProvider), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(ICatalogueFilter), typeof(CatalogueFilter), TypeOfRegistrationScope.Singleton)]

// view models
[assembly: InternalRegistration(typeof(IMainLayoutComponent), typeof(MainLayoutComponent), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(IHeaderbarComponent), typeof(HeaderbarComponent), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(ISideMenuComponent), typeof(SideMenuComponent), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(IContentAreaComponent), typeof(ContentAreaComponent), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(IFooterbarComponent), typeof(FooterbarComponent), TypeOfRegistrationScope.Singleton)]
