// <copyright file="MainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2026 All rights reserved</copyright>
namespace Vssl.UnoUINugetInAppBuildIssue.ViewModels;

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Vssl.UnoUINugetInAppBuildIssue.ViewModelInterfaces;

/// <summary>
/// The main view model
/// </summary>
public class MainViewModel : IMainViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class
    /// </summary>
    public MainViewModel()
    {
        this.UseTipsAndHints = true;
        this.HintAndTipsText = "We really hope that this would build correctly";
        this.Theme = "Dark";
    }

    #region [ INotifyPropertyChanged Events ]

    /// <summary>
    /// Multicast event for property change notifications.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region [ IFrameworkPageViewModelBase Properties ]

    /// <summary>
    /// Gets a value indicating whether hints and tips should be displayed.
    /// </summary>
    public bool UseTipsAndHints { get; }

    /// <summary>
    /// Gets the hints and tips text.
    /// </summary>
    public string HintAndTipsText { get; }

    /// <summary>
    /// Gets the requtested theme.
    /// </summary>
    public string Theme { get; }

    #endregion

    /// <summary>
    /// Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">Name of the property used to notify listeners.  This
    /// value is optional and can be provided automatically when invoked from compilers
    /// that support <see cref="CallerMemberNameAttribute"/>.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
