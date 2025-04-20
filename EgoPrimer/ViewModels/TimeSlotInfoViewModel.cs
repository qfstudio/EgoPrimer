using EgoPrimer.Services;

namespace EgoPrimer.ViewModels;

public class TimeSlotInfoViewModel : ViewModelBase
{
    public string TextInfo { get; }

    public TimeSlotInfoViewModel()
    {
        var today = ChronicleService.GetToday();
        var weekYear = ChronicleService.GetCurrentWeekOfWeekYear();

        TextInfo = $"{today.Year}年第{weekYear}周";
    }
}
