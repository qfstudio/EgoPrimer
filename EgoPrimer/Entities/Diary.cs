using NodaTime;

namespace EgoPrimer.Entities;

public class Diary : EntityBase
{
    public Instant Datetime { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
