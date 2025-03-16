using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class FocusTimerWindow : ReactiveWindow<FocusTimerWindowViewModel>
{
    public FocusTimerWindow()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            Current = this;
            Disposable.Create(() => { Current = null; }).DisposeWith(disposables);
        });
    }

    public static FocusTimerWindow? Current { get; private set; }
}
