using Avalonia.ReactiveUI;
using EgoPrimer.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace EgoPrimer.Views;

public partial class DateTimeInfoView : ReactiveUserControl<DateTimeInfoViewModel>
{
    public DateTimeInfoView()
    {
        InitializeComponent();
        DataContext ??= new DateTimeInfoViewModel();

        this.WhenActivated(d => {});
    }
}
