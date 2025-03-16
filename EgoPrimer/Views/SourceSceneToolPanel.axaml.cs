using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public partial class SourceSceneToolPanel : ReactiveUserControl<SourceSceneViewModel>
{
    public SourceSceneToolPanel()
    {
        InitializeComponent();
    }
}
