using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;
using EgoPrimer.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace EgoPrimer;

static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        // db context
        collection.AddTransient<CoreContext>();
        collection.AddTransient<EditionContext>();
        
        // view model
        collection.AddTransient<MainViewModel>();

        // views
        collection.AddTransient<MainWindow>();
        collection.AddTransient<MainView>();
    }
}

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public ServiceProvider Provider { get; protected set; }

    public override void OnFrameworkInitializationCompleted()
    {
        InitConstants();
        EnsureDirs();
        InitDatabases();

        var collection = new ServiceCollection();
        collection.AddCommonServices();

        Provider = collection.BuildServiceProvider();
        var vm = Provider.GetRequiredService<MainViewModel>();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                WindowManager.Main = new MainWindow
                {
                    DataContext = vm,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                desktop.MainWindow = WindowManager.Main;
                break;

            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = vm
                };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void InitDatabases()
    {
        using var coreContext = new CoreContext();
        using var editionContext = new EditionContext();

        coreContext.Database.EnsureCreated();
        editionContext.Database.EnsureCreated();
    }

    private void InitConstants()
    {
        var roamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appDataFolder = Path.Combine(roamingFolder, "EgoPrimer");

        Constants.AppRoamingDir = appDataFolder;
    }

    private void EnsureDirs()
    {
        string[] dirs = [ Constants.AppRoamingDir, Constants.DbDir ];
        foreach (var dir in dirs)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
