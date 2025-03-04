
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using EgoPrimer.Views;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace EgoPrimer.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ObservableCollection<ISceneViewModel> Scenes { get; } = new();

    private ObservableAsPropertyHelper<ISceneViewModel> _currentScene;
    public ISceneViewModel CurrentScene => _currentScene.Value;

    public MainViewModel(HomeSceneViewModel homeScene)
    {
        Scenes.Add(homeScene);

        _currentScene = this.WhenAnyValue(x => x.Scenes)
            .Select(scenes => scenes[0])
            .ToProperty(this, x => x.CurrentScene);
    }
}
