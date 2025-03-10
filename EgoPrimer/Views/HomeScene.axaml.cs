using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.ReactiveUI;
using Avalonia.VisualTree;
using EgoPrimer.ViewModels;

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
        throw new System.NotImplementedException();
    }
}
