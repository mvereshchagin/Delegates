namespace Delegates;

public static class CollectionUtils<T>
{
    public delegate bool Filter(T item);

    public static IEnumerable<T> DoFilter(IEnumerable<T> list, Filter filter)
    {
        List<T> newList = new List<T>();
        foreach(var item in list)
            if(filter(item))
                newList.Add(item);

        return newList;
    }
}
