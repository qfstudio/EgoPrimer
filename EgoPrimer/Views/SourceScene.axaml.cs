using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class SourceScene : ReactiveUserControl<SourceSceneViewModel>
{
    public SourceScene()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            ViewModel!.EditSourceInteraction.RegisterHandler(DoEditSourceInteraction).DisposeWith(disposables);
        });
    }

    private static async Task DoEditSourceInteraction(IInteractionContext<Source?, Source?> context)
    {
        var editor = new SourceEditorSceneViewModel();
        await MainView.Current!.ShowScene(editor);
        context.SetOutput(editor.GetModel());
    }
}
