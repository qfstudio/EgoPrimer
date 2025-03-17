using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public partial class SourceEditorScene : ReactiveUserControl<SourceEditorSceneViewModel>
{
    public SourceEditorScene()
    {
        InitializeComponent();
    }
}
