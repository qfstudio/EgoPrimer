using System.Threading;

namespace EgoPrimer;

public static class Globals
{
    public static ManualResetEvent DatabaseIsReady { get; } = new (false);
}
