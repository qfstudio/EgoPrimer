using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using EgoPrimer.Entities;
using NodaTime;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceSceneViewModel : SceneViewModelBase
{
    public override string Name => "Sources";

    public ObservableCollection<Source> Sources { get; } = [
        new () { Name = "QQ邮箱", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() },
        new () { Name = "WizNote", LastCheckedAt = SystemClock.Instance.GetCurrentInstant() }
    ];

    [Reactive]
    private Source? _selectedSource;

    public IObservable<bool> AnyItemSelected { get; }

    public ReactiveCommand<Unit, Unit> UpdateLastCheckedPropertyCommand { get; }

    public ReactiveCommand<Unit, Unit> ClearLastCheckedPropertyCommand { get; }

    public ReactiveCommand<Unit, Unit> RemoveSelectedItemCommand { get; }

    public SourceSceneViewModel()
    {
        AnyItemSelected = this.WhenAnyValue(x => x.SelectedSource)
            .Select(x => x != null);

        UpdateLastCheckedPropertyCommand = ReactiveCommand.Create(() =>
        {
            SelectedSource!.LastCheckedAt = SystemClock.Instance.GetCurrentInstant();

        }, AnyItemSelected);

        ClearLastCheckedPropertyCommand = ReactiveCommand.Create(() =>
        {
            SelectedSource!.LastCheckedAt = null;
        }, AnyItemSelected);

        RemoveSelectedItemCommand = ReactiveCommand.Create(() =>
        {
            Sources.Remove(SelectedSource!);
            SelectedSource = null;
        }, AnyItemSelected);
    }
}
