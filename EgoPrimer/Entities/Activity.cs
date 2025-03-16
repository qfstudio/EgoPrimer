﻿using NodaTime;

namespace EgoPrimer.Entities;

public class Activity : EntityBase
{
    public Instant StartedAt { set; get; }

    public Instant EndedAt { set; get; }

    public string Description { set; get; } = string.Empty;

    public Focus? Focus { set; get; }
}

public class ActivityType : EntityBase
{
    public string Name { set; get; } = string.Empty;

    public string Description { set; get; } = string.Empty;
}
