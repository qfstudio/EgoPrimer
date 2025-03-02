
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Avalonia.Controls;
using EgoPrimer.Views;
using ReactiveUI;

namespace EgoPrimer.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly Stack<UserControl> _views = new();
    public Stack<UserControl> Views => _views;

    private readonly ObservableAsPropertyHelper<UserControl> _content;
    public UserControl Content => _content.Value;

    private ObservableAsPropertyHelper<UserControl> _toolbar;
    public UserControl Toolbar => _toolbar.Value;

    public MainViewModel()
    {
        this.WhenAnyValue(x => x.Views)
            .Select(x => x.Peek())
            .ObserveOn(RxApp.MainThreadScheduler)
            .ToProperty(this, x => x.Content, out _content);
    }

    public void PushView(UserControl view)
    {
        _views.Push(view);
    }

    public void PopView()
    {
        if (_views.Count > 1)
        {
            _views.Pop();
            this.RaisePropertyChanged(nameof(Views));
        }
    }
}
