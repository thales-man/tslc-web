// -----------------------------------------------------------------------------
// copyright (c) 2020, the striped lawn company limited. all rights reserved.
// the striped lawn company licenses this file to you under the GPLv3 license.
// see the LICENSE file in the project root for more information.
// -----------------------------------------------------------------------------
using Document.API.Adapters;
using Document.API.Configuration;
using Document.API.Coordinators;
using Document.API.Factories;
using Tiny.Framework.Registration.Attributes;

// Project level
// Adapters
[assembly: InternalRegistration(typeof(IAdaptFileRetrieval), typeof(FileRetrievalAdapter), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(IAdaptCatalogueRetrieval), typeof(CatalogueRetrievalAdapter), TypeOfRegistrationScope.Singleton)]

// Coordinators
[assembly: InternalRegistration(typeof(ICoordinateFileRetrieval), typeof(FileRetrievalCoordinator), TypeOfRegistrationScope.Singleton)]
[assembly: InternalRegistration(typeof(ICoordinateCatalogueRetrieval), typeof(CatalogueRetrievalCoordinator), TypeOfRegistrationScope.Singleton)]

// Factories
[assembly: InternalRegistration(typeof(ICreatePostedArticleAccessScopes), typeof(PostedArticleAccessScopeFactory), TypeOfRegistrationScope.Singleton)]

// Configuration
[assembly: ConfigurationRegistration(typeof(IConfigurePostedArticleAccessScope), typeof(PostedArticleAccessScopeConfiguration), "Catalogue")]
