
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using DynamicData.Binding;
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

        _currentScene = Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => (sender, e) => handler(e),
                handler => Scenes.CollectionChanged += handler,
                handler => Scenes.CollectionChanged -= handler)
            .Select(_ => Scenes.Last())
            .ToProperty(this, x => x.CurrentScene, Scenes.Last());
    }

    public void PushScene(ISceneViewModel vm)
    {
        Scenes.Add(vm);
    }
}
