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

    private async Task DoEditSourceInteraction(IInteractionContext<Source?, Source?> context)
    {
        var editor = new SourceEditorSceneViewModel
        {
            Model = context.Input
        };
        await this.ShowScene(editor);
        context.SetOutput(editor.GetModel());
    }
}
