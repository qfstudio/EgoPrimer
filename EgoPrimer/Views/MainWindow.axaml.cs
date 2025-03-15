using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
    }
}
