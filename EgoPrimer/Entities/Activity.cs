using NodaTime;

namespace EgoPrimer.Entities;

public class Activity : EntityBase
{
    public Instant StartedAt { set; get; }

    public Instant EndedAt { set; get; }

    public Focus? Focus { set; get; }
}
