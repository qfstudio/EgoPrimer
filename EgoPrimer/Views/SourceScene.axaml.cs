using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.Entities;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class SourceScene : ReactiveUserControl<SourceSceneModel>
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
        var editor = new SourceEditorSceneModel
        {
            Model = context.Input
        };
        await this.ShowScene(editor);
        context.SetOutput(editor.GetModel());
    }
}
