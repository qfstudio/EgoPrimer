using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using NodaTime;

namespace EgoPrimer.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var t1 = new LocalTime(3, 0);
        var t2 = new LocalTime(1, 30);
        var ts = Period.Between(t1, t2).ToDuration().TotalSeconds;
        if (ts < 0)
        {
            ts = -ts;
        }

        var d = Duration.FromSeconds(ts);
    }
}
