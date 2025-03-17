using Avalonia.Controls;
using Avalonia.Controls.Templates;
using EgoPrimer.ViewModels;

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
    public Type? TryGetType(object? param)
    {
        return param is ViewModelBase vm ? vm.GetType() : null;
    }
    
    public Control? Build(object? param)
    {
        throw new NotImplementedException();
    }

    public bool Match(object? data)
    {
        throw new NotImplementedException();
    }
}


