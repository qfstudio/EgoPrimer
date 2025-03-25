using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Avalonia.Threading;
using DynamicData;
using EgoPrimer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceSceneViewModel : SceneViewModelBase
{
    public override string Name => "Sources";

    public ObservableCollection<Source> Sources { get; } = [];

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
        _coreContext = new CoreContext();

        AnyItemSelected = this.WhenAnyValue(x => x.SelectedSource)
            .Select(x => x != null);

        AnyItemSelected.Subscribe(x => Console.WriteLine($"AnyItemSelected: {x}, SelectedSource: {SelectedSource?.Name}"));

        AddSourceCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var source = await EditSourceInteraction.Handle(null);
            if (source != null)
            {
                _coreContext.Add(source);
                _coreContext.SaveChanges();
            }
        });

        EditSourceCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            if (SelectedSource == null) return;
            await EditSourceInteraction.Handle(SelectedSource);
            _coreContext.SaveChanges();
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

        this.WhenActivated(d =>
        {
            Sources.Clear();
            Sources.AddRange(_coreContext.Sources.ToList());

            d(Disposable.Empty);
        });
    }
}
