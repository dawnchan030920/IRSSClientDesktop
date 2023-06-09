﻿using IRSSClientDesktop.Activation;
using IRSSClientDesktop.Contracts.Services;
using IRSSClientDesktop.Core.Contracts.Services;
using IRSSClientDesktop.Core.Services;
using IRSSClientDesktop.Helpers;
using IRSSClientDesktop.Models;
using IRSSClientDesktop.Services;
using IRSSClientDesktop.ViewModels;
using IRSSClientDesktop.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace IRSSClientDesktop;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<ISearchService, SearchService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<RegisterPage>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<LoginPage>();
            services.AddTransient<ArticleDetailViewModel>();
            services.AddTransient<ArticleDetailPage>();
            services.AddTransient<BilibiliViewModel>();
            services.AddTransient<BilibiliPage>();
            services.AddTransient<ZhihuViewModel>();
            services.AddTransient<ZhihuPage>();
            services.AddTransient<WechatViewModel>();
            services.AddTransient<WechatPage>();
            services.AddTransient<QQViewModel>();
            services.AddTransient<QQPage>();
            services.AddTransient<NoteViewModel>();
            services.AddTransient<NotePage>();
            services.AddTransient<FavoriteViewModel>();
            services.AddTransient<FavoritePage>();
            services.AddTransient<SourceViewModel>();
            services.AddTransient<SourcePage>();
            services.AddTransient<AnswerViewModel>();
            services.AddTransient<AnswerPage>();
            services.AddTransient<ArticleViewModel>();
            services.AddTransient<ArticlePage>();
            services.AddTransient<MessageViewModel>();
            services.AddTransient<MessagePage>();
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomePage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
