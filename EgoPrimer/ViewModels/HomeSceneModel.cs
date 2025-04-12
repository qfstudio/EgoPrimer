using ReactiveUI.SourceGenerators;

namespace EgoPrimer.ViewModels;

public partial class HomeSceneModel : SceneModelBase
{
    public override string Name => "Home";

    [Reactive]
    private int _selectedTabIndex = 0;
}
