using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using EgoPrimer.ViewModels;
using EgoPrimer.Views;
using Microsoft.Extensions.DependencyInjection;

namespace EgoPrimer;

static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainViewModel>();
        
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

    public override void OnFrameworkInitializationCompleted()
    {
        var collection = new ServiceCollection();
        collection.AddCommonServices();

        var serviceProvider = collection.BuildServiceProvider();
        var vm = serviceProvider.GetRequiredService<MainViewModel>();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = vm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}