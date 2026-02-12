// <copyright file="UIDispatcher.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013, 2019 All rights reserved</copyright>

namespace Vssl.Samples.Framework;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vssl.Samples.FrameworkInterfaces;
using Windows.UI.Core;

/// <summary>
/// A UWP platform specific implementation of the UI Dispatcher facade
/// </summary>
public class UIDispatcher : IDispatchOnUIThread
{
#if !NET6_0_OR_GREATER && !NETSTANDARD2_0
    /// <summary>
    /// The UWP platform dispatcher
    /// </summary>
    private CoreDispatcher dispatcher;
#else
    private SynchronizationContext dispatcher;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="UIDispatcher"/> class.
    /// </summary>
    public UIDispatcher()
    {
    }

    /// <summary>
    /// Initialise the dispatcher
    /// </summary>
    public void Initialize()
    {
        this.dispatcher = SynchronizationContext.Current;
    }

    /// <summary>
    /// Check the dispatcher is initialised and if not initialise it
    /// </summary>
    public void CheckDispatcher()
    {
        if (this.dispatcher == null)
        {
            this.Initialize();
        }
    }

    /// <summary>
    /// Execute an action via the dispatcher
    /// </summary>
    /// <param name="action">The action</param>
    public void Invoke(Action action)
    {
        this.Execute(action);
    }

    /// <summary>
    /// Async Execution of an action via the dispatcher
    /// </summary>
    /// <param name="action">The action</param>
    /// <returns>An awaitable task</returns>
    public async Task InvokeAsync(Action action)
    {
        await this.ExecuteAsync(action);
    }

    /// <summary>
    /// Execute an action via the dispatcher
    /// </summary>
    /// <param name="action">The action</param>
    public void Execute(Action action)
    {
        if (this.dispatcher == null || SynchronizationContext.Current == this.dispatcher)
        {
            action();
        }
        else
        {
            // Not awated execution will continue before the action has completed
            this.dispatcher.Post((object state) => action(), null);
        }
    }

    /// <summary>
    /// Execute a function via the dispatcher
    /// </summary>
    /// <param name="action">The action</param>
    /// <returns>An awaitable task</returns>
    public async Task ExecuteAsync(Action action)
    {
        if (this.dispatcher == null || SynchronizationContext.Current == this.dispatcher)
        {
            action();
        }
        else
        {
            var tcs = new TaskCompletionSource<object>();
            try
            {
                this.dispatcher.Post(
                    (object state) =>
                    {
                        action();
                        tcs.TrySetResult(null);
                    },
                    null);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }

            await tcs.Task.ConfigureAwait(false);
        }
    }
}
