using EgoPrimer.Entities;
using NodaTime;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceEditorSceneViewModel: SceneViewModelBase
{
    [Reactive]
    private string _sourceName;

    [Reactive]
    private string _sourceDescription;

    [Reactive]
    private bool _sourceIsChecked;

    public override string Name => "Source Editor";

    public Source GetModel()
    {
        return new Source()
        {
            Name = _sourceName,
            Description = _sourceDescription,
            CreatedAt = SystemClock.Instance.GetCurrentInstant(),
            LastCheckedAt = _sourceIsChecked ? SystemClock.Instance.GetCurrentInstant() : null,
        };
    }
}
