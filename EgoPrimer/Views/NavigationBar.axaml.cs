using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public partial class NavigationBar : ReactiveUserControl<MainViewModel>
{
    public NavigationBar()
    {
        InitializeComponent();
    }
}
