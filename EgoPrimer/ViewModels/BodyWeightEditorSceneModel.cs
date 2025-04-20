using System.Reactive;
using ReactiveUI;

namespace EgoPrimer.ViewModels;

public class BodyWeightEditorSceneModel : SceneModelBase
{
    public override string Name => "Body Weight Editor";

    public ReactiveCommand<Unit, Unit> ConfirmEdition { get; }

    public ReactiveCommand<Unit, Unit> DiscardEdition { get; }



    public BodyWeightEditorSceneModel()
    {
        // ConfirmEdition = ReactiveCommand.Create();
        //
        // DiscardEdition = ReactiveCommand.Create();
    }
}
