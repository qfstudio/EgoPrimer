using System.Diagnostics;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace EgoPrimer.Views;

public partial class SettingsScene : UserControl
{
    public SettingsScene()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var startInfo = new ProcessStartInfo()
        {
            Arguments = Constants.AppRoamingDir,
            FileName = "explorer.exe"
        };
        Process.Start(startInfo);

        Dispatcher.UIThread.InvokeAsync(async () =>
        {
            var b = (Button)sender!;
            b.IsEnabled = false;
            await Task.Delay(3000);
            b.IsEnabled = true;
        });
    }
}
