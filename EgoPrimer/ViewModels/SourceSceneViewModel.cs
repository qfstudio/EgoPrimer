using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using EgoPrimer.Entities;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceSceneViewModel : SceneViewModelBase
{
    public override string Name => "Sources";
    
    public ObservableCollection<Source> Sources { get; } = [
        new () { Name = "QQ邮箱", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() },
        new () { Name = "WizNote", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() },
        new () { Name = "Hotmail", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() },
        new () { Name = "Wechat", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() }
    ];

    [Reactive]
    private Source? _selectedSource;

    private CoreContext _coreContext;
    
    public IObservable<bool> AnyItemSelected { get; }
    
    public Interaction<Source?, Source?> EditSourceInteraction { get; } = new();
    
    public ReactiveCommand<Unit, Unit> AddSourceCommand { get; }
    
    public ReactiveCommand<Unit, Unit> EditSourceCommand { get; }
    
    public ReactiveCommand<Unit, Unit> UpdateLastCheckedPropertyCommand { get; }

    public ReactiveCommand<Unit, Unit> ClearLastCheckedPropertyCommand { get; }

    public ReactiveCommand<Unit, Unit> RemoveSelectedItemCommand { get; }

    public SourceSceneViewModel()
    {
        _coreContext = App.Current!.Provider.GetRequiredService<CoreContext>();

        AnyItemSelected = this.WhenAnyValue(x => x.SelectedSource)
            .Select(x => x != null);

        AnyItemSelected.Subscribe(x => Console.WriteLine($"AnyItemSelected: {x}, SelectedSource: {SelectedSource?.Name}"));

        AddSourceCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await EditSourceInteraction.Handle(null);
        });

        EditSourceCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedSource == null) return;
            await EditSourceInteraction.Handle(SelectedSource);
        }, AnyItemSelected);
        
        UpdateLastCheckedPropertyCommand = ReactiveCommand.Create(() =>
        {
            if (SelectedSource == null) return;
            SelectedSource.LastCheckedAt = SystemClock.Instance.GetCurrentInstant();
            SelectedSource.RaisePropertyChanged(nameof(SelectedSource.LastCheckedAt));
        }, AnyItemSelected);

        ClearLastCheckedPropertyCommand = ReactiveCommand.Create(() =>
        {
            if (SelectedSource == null) return;
            SelectedSource.LastCheckedAt = null;
            SelectedSource.RaisePropertyChanged(nameof(SelectedSource.LastCheckedAt));
        }, AnyItemSelected);

        RemoveSelectedItemCommand = ReactiveCommand.Create(() =>
        {
            Sources.Remove(SelectedSource!);
            SelectedSource = null;
        }, AnyItemSelected);
    }
}
