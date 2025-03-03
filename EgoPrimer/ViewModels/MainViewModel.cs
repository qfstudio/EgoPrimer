
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Avalonia.Controls;
using EgoPrimer.Views;
using ReactiveUI;

namespace EgoPrimer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly Stack<ISceneViewModel> _scenes = new();

    public MainViewModel()
    {

    }
}
