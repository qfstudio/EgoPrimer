namespace EgoPrimer.ViewModels;

public interface ISceneViewModel
{
    string Name { get; }
}

public abstract class SceneViewModelBase : ViewModelBase, ISceneViewModel
{
    public abstract string Name { get; }
}
