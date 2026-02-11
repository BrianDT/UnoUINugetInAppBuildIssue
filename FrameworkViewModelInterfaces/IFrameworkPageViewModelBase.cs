// <copyright file="IFrameworkPageViewModelBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2016 All rights reserved</copyright>
namespace FrameworkViewModelInterfaces;

using System.ComponentModel;

/// <summary>
/// Suppports hints and tips and theming.
/// </summary>
public interface IFrameworkPageViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Gets a value indicating whether hints and tips should be displayed.
    /// </summary>
    bool UseTipsAndHints { get; }

    /// <summary>
    /// Gets the hints and tips text.
    /// </summary>
    string HintAndTipsText { get; }

    /// <summary>
    /// Gets the requtested theme.
    /// </summary>
    string Theme { get; }
}
