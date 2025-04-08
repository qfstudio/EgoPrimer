using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace EgoPrimer.Views;

public partial class HomeScene : ReactiveUserControl<HomeSceneViewModel>
{
    public HomeScene()
    {
        InitializeComponent();
    }

    private void OpenSettingsSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new SettingsSceneViewModel());
    }

    private void OpenFocusSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new FocusSceneViewModel());
    }

    private void OpenCalendarButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new CalendarSceneViewModel());
    }

    private void OpenNextActionsSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new NextActionsSceneViewModel());
    }

    private void OpenProjectsSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new ProjectsSceneViewModel());
    }

    private void OpenInboxSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new InboxSceneViewModel());
    }

    private void OpenWaitingSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new WaitingSceneViewModel());
    }

    private void OpenIncubationSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new IncubationSceneViewModel());
    }

    private void OpenCollectSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new InboxSceneViewModel());
    }

    private void OpenSourceSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new SourceSceneViewModel());
    }

    private void OpenChronicleSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new ChronicleSceneViewModel());
    }

    private void OpenActivityRecordsSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new ActivityRecordsSceneViewModel());
    }

    private void OpenHealthSceneButton_OnClick(object? sender, RoutedEventArgs e)
    {
        MainView.Current?.NavigateTo(new HealthSceneViewModel());
    }
}
