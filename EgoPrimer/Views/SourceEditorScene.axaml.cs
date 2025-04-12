using System.Reactive.Disposables;
using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class SourceEditorScene : ReactiveUserControl<SourceEditorSceneModel>
{
    public SourceEditorScene()
    {
        InitializeComponent();

        this.WhenActivated(disposables =>
        {
            ViewModel!.ConfirmEdition.Subscribe(_ => this.GoBack()).DisposeWith(disposables);
            ViewModel!.DiscardEdition.Subscribe(_ => this.GoBack()).DisposeWith(disposables);
        });
    }
}
