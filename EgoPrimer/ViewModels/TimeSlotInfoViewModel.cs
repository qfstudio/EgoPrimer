using EgoPrimer.Services;
using NodaTime.Calendars;

namespace EgoPrimer.ViewModels;

public class TimeSlotInfoViewModel : ViewModelBase
{
    public string TextInfo { get; }

    public TimeSlotInfoViewModel()
    {
        var today = ChronicleService.GetToday().LocalDateTime.Date;
        var weekYear = WeekYearRules.Iso.GetWeekYear(today);
        var week = WeekYearRules.Iso.GetWeekOfWeekYear(today);

        TextInfo = $"{weekYear}年第{week}周";
    }
}
