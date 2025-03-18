using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using ReactiveUI;

namespace EgoPrimer.ViewModels;

public interface ISceneViewModel
{
    string Name { get; }
    
    IObservable<Unit> Activated { get; }
    
    IObservable<Unit> Deactivated { get; }
}

public abstract class SceneViewModelBase : ViewModelBase, ISceneViewModel, IActivatableViewModel
{
    public abstract string Name { get; }

    public ViewModelActivator Activator { get; } = new();

    private readonly Subject<Unit> _activated = new();
    private readonly Subject<Unit> _deactivated = new();
     
    public IObservable<Unit> Activated => _activated;
    public IObservable<Unit> Deactivated => _deactivated;
    
    protected SceneViewModelBase()
    {
        this.WhenActivated(disposables =>
        {
            _activated.OnNext(new Unit());
            Disposable.Create(() => _deactivated.OnNext(new Unit())).DisposeWith(disposables);
        });
    }
}
