using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            TopWindows.MainWindow = this;
            Disposable.Create(() => {}).DisposeWith(disposables);
        });
    }
}
