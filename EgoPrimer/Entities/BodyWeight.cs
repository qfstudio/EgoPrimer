using NodaTime;

namespace EgoPrimer.Entities;

public class BodyWeight : EntityBase
{
    public Instant Date { get; set; }
    
    public float Weight { get; set; }
}