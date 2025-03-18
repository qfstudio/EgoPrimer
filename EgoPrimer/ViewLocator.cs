using Avalonia.Controls;
using Avalonia.Controls.Templates;
using EgoPrimer.ViewModels;
using EgoPrimer.Views;

namespace EgoPrimer;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? data)
    {
        if (data is null)
            return null;

        var name = data.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}

public class SceneLocator : IDataTemplate
{
    public virtual Control? GetStubControl()
    {
        return new StubScene();
    }

    public virtual Type? GetCorrespondingControlType(SceneViewModelBase? vm)
    {
        if (vm is null)
            return null;

        var name = vm.GetType().FullName!
            .Replace("SceneViewModel", "Scene", StringComparison.Ordinal)
            .Replace(".ViewModels", ".Views", StringComparison.Ordinal);
        return Type.GetType(name);
    }
    
    public Control? Build(object? data)
    {
        if (data is not SceneViewModelBase vm)
            return new StubScene();

        var type = GetCorrespondingControlType(vm);
        if (type == null)
            return GetStubControl();

        var control = (Control)Activator.CreateInstance(type)!;
        control.DataContext = data;
        return control;
    }

    public bool Match(object? data)
    {
        return data is SceneViewModelBase;
    }
}

public class SceneToolPanelLocator : SceneLocator
{
    public override Control? GetStubControl()
    {
        return new StubSceneToolPanel();
    }

    public override Type? GetCorrespondingControlType(SceneViewModelBase? vm)
    {
        if (vm is null)
            return null;

        var name = vm.GetType().FullName!
            .Replace("SceneViewModel", "SceneToolPanel", StringComparison.Ordinal)
            .Replace(".ViewModels", ".Views", StringComparison.Ordinal);
        return Type.GetType(name);
    }
}
