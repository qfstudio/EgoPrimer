using Avalonia.Controls;

namespace EgoPrimer.ViewModels;

public class HomeSceneViewModel : ISceneVIewModel
{
    public UserControl GetScene()
    {
        return new HomeSceneView();
    }

    public UserControl? GetToolPanel()
    {
        return null;
    }
}