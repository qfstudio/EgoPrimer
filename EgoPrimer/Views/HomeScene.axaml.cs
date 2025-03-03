using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace EgoPrimer.Views;

public partial class HomeScene : UserControl
{
    public HomeScene()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Content = new SettingsScene();
    }
}
