using System.Threading.Tasks;
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

        this.WhenActivated(action => action(ViewModel!.EditSourceInteraction.RegisterHandler(DoEditSourceInteractionAsync)));
    }

    async Task DoEditSourceInteractionAsync(IInteractionContext<Source?, Source?> interaction)
    {
        SourceEditorSceneViewModel editor = new();
        var output = await editor.EditSourceAsync(interaction.Input);
    }
    
}
