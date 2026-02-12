// <copyright file="MainPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2026 All rights reserved</copyright>
namespace Vssl.UnoUINugetInAppBuildIssue.TopLevelControls;

using Microsoft.UI.Xaml.Controls;
using Vssl.Samples.Framework;
using Vssl.UnoUINugetInAppBuildIssue.ViewModelInterfaces;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class
    /// </summary>
    public MainPage()
    {
        this.InitializeComponent();

        this.DataContext = DependencyHelper.Resolve<IMainViewModel>();
    }

    /// <summary>
    /// Gets the typed data context.
    /// </summary>
    public IMainViewModel? VM => this.DataContext as IMainViewModel;
}
