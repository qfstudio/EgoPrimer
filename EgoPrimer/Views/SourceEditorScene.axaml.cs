using System.Threading.Tasks;
using Avalonia.Controls;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;

namespace EgoPrimer.Views;

public partial class SourceEditorScene : UserControl
{
    public SourceEditorScene()
    {
        InitializeComponent();
        DataContext ??= new SourceEditorSceneViewModel();
    }

    public async Task<Source?> ShowEditorAsync(Source? source)
    {
        if (MainView.Current == null || this.DataContext is not SourceEditorSceneViewModel)
            return null;

        MainView.Current.NavigateTo((SourceEditorSceneViewModel)DataContext);

        // TODO 添加获得Source的逻辑

        MainView.Current.NavigateBack();
        return new Source();
    }
}
