using System.Threading.Tasks;
using EgoPrimer.Entities;
using NodaTime;
using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class SourceEditorSceneViewModel: SceneViewModelBase
{
    [Reactive]
    private string _sourceName = string.Empty;

    [Reactive]
    private string _sourceDescription = string.Empty;

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

    public void SetModel(Source? source)
    {
        SourceName = source.Name;
        SourceDescription = source.Description;
        SourceIsChecked = source.LastCheckedAt.HasValue;
    }

    public async Task<Source?> EditSourceAsync(Source? source)
    {
        // TODO
        return source;
    }
}
