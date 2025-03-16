using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class DateTimeInfoViewModel : ViewModelBase, IActivatableViewModel
{
    public ViewModelActivator Activator { get; } = new();

    [Reactive]
    private string _info;

    public DateTimeInfoViewModel()
    {
        this.WhenActivated(disposables =>
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(200))
                .Select(_ => DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss"))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(info => Info = info)
                .DisposeWith(disposables);
        });
    }
}
