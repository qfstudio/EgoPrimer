using System.Reactive;
using EgoPrimer.Entities;
using NodaTime;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceEditorSceneViewModel: SceneViewModelBase
{
    public override string Name => "Source Editor";
    
    [Reactive]
    private string _sourceName = string.Empty;

    [Reactive]
    private string _sourceDescription = string.Empty;

    [Reactive]
    private bool _sourceIsChecked;

    private Source? _model;

    public Source? Model
    {
        get => _model;
        set
        {
            this.RaiseAndSetIfChanged(ref _model, value);

            if (value != null)
            {
                SourceName = value.Name;
                SourceDescription = value.Description;
                SourceIsChecked = value.LastCheckedAt.HasValue;
            }
        }
    }

    public ReactiveCommand<Unit, Unit> ConfirmEdition { get; }

    public ReactiveCommand<Unit, Unit> DiscardEdition { get; }

    public Source? GetModel()
    {
        return _model;
    }

    public SourceEditorSceneViewModel()
    {
        ConfirmEdition = ReactiveCommand.Create(() =>
        {
            _model ??= new Source();
            _model.Name = _sourceName;
            _model.Description = _sourceDescription;
            _model.LastCheckedAt = _sourceIsChecked ? SystemClock.Instance.GetCurrentInstant() : null;
        });

        DiscardEdition = ReactiveCommand.Create(() => {});
    }
}
