using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;

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
        ObservableCollection<int> collection = new();
        
        var d = Observable.FromEvent<System.Collections.Specialized.NotifyCollectionChangedEventHandler, 
            System.Collections.Specialized.NotifyCollectionChangedEventArgs>(
            handler => (sender, e) => handler(e),
            handler => collection.CollectionChanged += handler,
            handler => collection.CollectionChanged -= handler
        ).Subscribe(args => Console.WriteLine(args.ToString()));
        
        collection.Add(1);
        collection.Add(2);
        
        d.Dispose();
        Assert.Pass();
    }
}
