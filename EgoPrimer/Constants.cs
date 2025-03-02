
using System.IO;
using Avalonia.Platform;

namespace EgoPrimer;

public static class Constants
{
    public static string AppRoamingDir { get; set; } = "";

    public static string DbDir => Path.Combine(AppRoamingDir, "Databases");

    public static string CoreDbPath => Path.Combine(DbDir, "core.sqlite3");

    public static string EditionDbPath => Path.Combine(DbDir, "editions.sqlite3");
}
