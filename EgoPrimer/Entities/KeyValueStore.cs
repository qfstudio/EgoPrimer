using Microsoft.EntityFrameworkCore;

namespace EgoPrimer.Entities;

[Index(nameof(Key), IsUnique = true)]
public class KeyValueStore : EntityBase
{
    public string Key { get; set; }

    public string Value { get; set; }
}
