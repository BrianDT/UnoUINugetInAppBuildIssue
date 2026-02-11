// <copyright file="ReusableControl.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2014, 2026 All rights reserved</copyright>
namespace Vssl.VisualFramework.SampleLibrary;

using FrameworkViewModelInterfaces;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

/// <summary>
/// Display the hints and tips section at the foot of the page
/// </summary>
public sealed partial class ReusableControl : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReusableControl"/> class
    /// </summary>
    public ReusableControl()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Gets the interface to the view model used for compile time binding
    /// </summary>
    public IFrameworkPageViewModelBase? VM
    {
        get
        {
            return this.DataContext as IFrameworkPageViewModelBase;
        }
    }
}
