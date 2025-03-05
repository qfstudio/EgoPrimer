using System;
using System.Reactive.Subjects;
using Avalonia.Controls;

namespace EgoPrimer.ViewModels;

public class NavigationRequest(Type destination)
{
    public Type Destination { get; } = destination;
}

public interface ISceneViewModel
{
    string Name { get; }
    
    Subject<NavigationRequest> NavigationRequest { get; }
}

public abstract class SceneViewModelBase : ViewModelBase, ISceneViewModel
{
    public abstract string Name { get; }
    
    public Subject<NavigationRequest> NavigationRequest { get; } = new();
}
