// <copyright file="MSServiceContainer.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.UnoUINugetInAppBuildIssue.Initialisation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID || __IOS__
using Microsoft.Extensions.Configuration;
#endif
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSExtFacade;
using Vssl.Samples.Framework;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.UnoUINugetInAppBuildIssue.ViewModelInterfaces;
using Vssl.UnoUINugetInAppBuildIssue.ViewModels;

/// <summary>
/// Dependepcy injection manager
/// </summary>
public class MSServiceContainer
{
    /// <summary>
    /// returns the container
    /// </summary>
    /// <returns>This class as a container</returns>
    public IDependencyResolver PopulateContainer()
    {
#if ANDROID || __IOS__
        IConfiguration config = ConfigurationHelper.BuildConfig("appsettings.json");
#endif
        var services = new ServiceCollection();
#if ANDROID || __IOS__
        services.AddTransient<IConfiguration>(_ => config);
#endif

        // Framework
        services.AddSingleton<IDependencyResolver, MSExtDI>()
        .AddSingleton<IDispatchOnUIThread, UIDispatcher>();

        // Services
        ////services.AddSingleton<ISampleService, SampleService>();

        // View models
        services.AddTransient<IMainViewModel, MainViewModel>();

        var serviceProvider = services.BuildServiceProvider();
        var diFacade = serviceProvider.GetRequiredService<IDependencyResolver>();
        ((MSExtDI)diFacade).Configure(serviceProvider);

        return diFacade;
    }
}
