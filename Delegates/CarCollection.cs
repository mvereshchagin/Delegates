using System.Collections.Specialized;

namespace Delegates;

internal class CarCollection : List<Car>, INotifyCollectionChanged
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;
}
