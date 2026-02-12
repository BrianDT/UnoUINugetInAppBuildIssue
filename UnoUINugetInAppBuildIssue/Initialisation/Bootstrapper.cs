// <copyright file="Bootstrapper.cs" company="Visual Software Systems Ltd.">Copyright (c) 2019, 2026 All rights reserved</copyright>
namespace Vssl.UnoUINugetInAppBuildIssue.Initialisation;

using System;
using System.Collections.Generic;
using System.Text;

using Vssl.Samples.Framework;
using Vssl.Samples.FrameworkInterfaces;

/// <summary>
/// Bootstraps the DI
/// </summary>
public class Bootstrapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bootstrapper"/> class.
    /// </summary>
    public Bootstrapper()
    {
    }

    /// <summary>
    /// Create the DI container and register all classes against their interfaces
    /// </summary>
    /// <returns>The interface to the DI facade</returns>
    public IDependencyResolver Startup()
    {
        IDependencyResolver diFacade = null;
        var containerCreator = new MSServiceContainer();
        diFacade = containerCreator.PopulateContainer();
        DependencyHelper.Container = diFacade;

        // ensure the singleton dispatcher is created.
        var dispatcher = diFacade.Resolve<IDispatchOnUIThread>();
        dispatcher.Initialize();

        return diFacade;
    }
}
