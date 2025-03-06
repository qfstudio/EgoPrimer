
using System.IO;
using Avalonia.Platform;

namespace EgoPrimer;

public static class Constants
{
    public static string AppRoamingDataDir { get; set; } = "";

    public static string AppLocalDataDir { get; set; } = "";

    public static string DbDir => Path.Combine(AppRoamingDataDir, "Databases");

    public static string CoreDbPath => Path.Combine(DbDir, "core.sqlite3");

    public static string EditionDbPath => Path.Combine(DbDir, "editions.sqlite3");

    public static string AppSettingsPath => Path.Combine(AppLocalDataDir, "settings.toml");
}
