using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;
using EgoPrimer.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EgoPrimer;

static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        // Database contexts
        collection.AddTransient<CoreContext>();
        collection.AddTransient<EditionContext>();
        
        // View models
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<MainViewModel>();
        collection.AddTransient<HomeSceneViewModel>();
        collection.AddTransient<SettingsSceneViewModel>();
        collection.AddTransient<SourceSceneViewModel>();

        // Views
        collection.AddTransient<MainWindow>();
        collection.AddTransient<MainView>();
    }
}

public partial class App : Application
{
    public App()
    {
        var collection = new ServiceCollection();
        collection.AddCommonServices();

        Provider = collection.BuildServiceProvider();
    }

    public new static App Current => (App)(Application.Current!);

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public ServiceProvider Provider { get; protected set; }

    public AppSettings Settings => AppSettingsManager.CurrentSettings;

    public override void OnFrameworkInitializationCompleted()
    {
        InitConstants();
        EnsureLocalDataDirs();
        InitSettings();
        EnsureRoamingDataDirs();
        InitDatabases();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Provider.GetRequiredService<MainWindowViewModel>(),
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                break;

            case ISingleViewApplicationLifetime singleViewPlatform:
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = Provider.GetRequiredService<MainViewModel>()
                };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void InitSettings()
    {
        AppSettingsManager.MakeSettingsAvailable();
    }

    private void InitDatabases()
    {
        using var coreContext = new CoreContext();
        using var editionContext = new EditionContext();

        coreContext.Database.EnsureCreated();
        editionContext.Database.EnsureCreated();
        Globals.DatabaseIsReady.Set();
    }

    private void InitConstants()
    {
        var dataDirName = Environment.GetEnvironmentVariable("EGO_PRIMER_DATA_DIR_NAME");
        if (dataDirName != null)
        {
            Constants.DataDirNameOverwrite = dataDirName;
        }
        else
        {
            dataDirName ??= "EgoPrimer";
        }

        var roamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appRoamingDataFolder = Path.Combine(roamingFolder, dataDirName);

        var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var appLocalDataFolder = Path.Combine(localFolder, dataDirName);

        Constants.AppRoamingDataDir = appRoamingDataFolder;
        Constants.AppLocalDataDir = appLocalDataFolder;
    }

    private void EnsureDirs(string[] dirs)
    {
        foreach (var dir in dirs)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
    
    private void EnsureLocalDataDirs()
    {
        EnsureDirs([ Constants.AppLocalDataDir ]);
    }
    
    private void EnsureRoamingDataDirs()
    {
        EnsureDirs([
            Constants.AppRoamingDataDir, Constants.DbDir
        ]);
    }
}
