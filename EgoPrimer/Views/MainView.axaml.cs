using System;
using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            Current = this;
            Disposable.Create(() => { Current = null; }).DisposeWith(disposables);
        });
    }

    public static MainView? Current { get; private set; }

    public void NavigateTo(ISceneViewModel vm)
    {
        if (DataContext is MainViewModel mainVm)
        {
            mainVm.PushScene(vm);
        }
    }
}
