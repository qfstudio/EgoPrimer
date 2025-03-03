using Avalonia.Styling;

namespace EgoPrimer.Entities;

public class Focus : EntityBase
{
    public string Title { set; get; } = "";

    public FocusMetadata Metadata { set; get; } = new();
}

public class FocusMetadata
{
    public int Kudos { set; get; }
    
    public int TotalKudos { set; get; }
}
