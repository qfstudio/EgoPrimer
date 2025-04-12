using ReactiveUI;

namespace EgoPrimer.ViewModels;

public partial class CalendarSceneModel : SceneModelBase
{
    public override string Name => "Calendar";

    private DateTime _selectedDate;
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set => this.RaiseAndSetIfChanged(ref _selectedDate, value);
    }
}
