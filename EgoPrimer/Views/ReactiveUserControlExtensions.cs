using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public static class ReactiveUserControlExtensions
{
    public static void GoBack<T>(this ReactiveUserControl<T> _) where T : SceneViewModelBase
    {
       MainView.Current!.NavigateBack();
    }

    public static void GoTo<T>(this ReactiveUserControl<T> _, ISceneViewModel vm) where T : SceneViewModelBase
    {
        MainView.Current!.NavigateTo(vm);
    }

    public static async Task ShowScene<T>(this ReactiveUserControl<T> _, ISceneViewModel vm) where T : SceneViewModelBase
    {
        await MainView.Current!.ShowScene(vm);
    }
}
