using System.Collections.ObjectModel;

namespace EgoPrimer.ViewModels;

public class HealthSceneModel : SceneModelBase
{
    public override string Name => "Health";

    public ObservableCollection<string> BodyWeightHighlights { get; } = [
        "Latest: kg",
        "Last 3 days: kg",
        "This Week: kg",
        "This Month: kg"
    ];

    public HealthSceneModel()
    {
    }
}
