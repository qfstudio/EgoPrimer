
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

        _currentScene = this.WhenAnyValue(x => x.Scenes)
            .Select(scenes => scenes.Last())
            .ToProperty(this, x => x.CurrentScene);

        // Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(
        //     handler => Scenes.CollectionChanged += (NotifyCollectionChangedEventHandler)handler,
        //     handler => Scenes.CollectionChanged -= handler);
    }

    public void PushScene(ISceneViewModel vm)
    {
        Scenes.Add(vm);
    }
}
