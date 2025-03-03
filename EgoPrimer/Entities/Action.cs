using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace EgoPrimer.Entities;

public class Action : EntityBase
{
    public Project? Project { set; get; }

    public string Description { set; get; } = "";
}

public class ActionType : EntityBase
{
    public string Name { set; get; } = "";

    public string Description { set; get; } = "";

    public string Shortcut { set; get; } = "";
}
