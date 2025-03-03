using Avalonia.Controls;

namespace EgoPrimer.ViewModels;

public interface ISceneVIewModel
{
    UserControl GetScene();

    UserControl? GetToolPanel();
}