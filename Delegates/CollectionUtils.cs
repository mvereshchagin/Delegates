namespace Delegates;

public static class CollectionUtils
{
    public delegate bool Filter<T>(T item);

    public static IEnumerable<T> DoFilter<T>(IEnumerable<T> list, Filter<T> filter)
    {
        List<T> newList = new List<T>();
        foreach(var item in list)
            if(filter(item))
                newList.Add(item);

        return newList;
    }

    // Predicate дедегат, принимающий лююые параметры и возвращающий bool
    public static IEnumerable<T> DoFilter2<T>(IEnumerable<T> list, Predicate<T> filter)
    {
        List<T> newList = new List<T>();
        foreach (var item in list)
            if (filter(item))
                newList.Add(item);

        return newList;
    }

    // Func 
    public static void Print<T>(IEnumerable<T> list, Func<T, string> format, string separator = ", ")
    {
        Console.WriteLine("");
        Console.WriteLine("===============================================");

        var formattedItems = new List<string>();
        foreach(var item in list)
        {
            var formattedString = format(item);
            formattedItems.Add(formattedString);
        }

        var resultString = String.Join(separator, formattedItems);
        Console.WriteLine(resultString);

        Console.WriteLine("===============================================");
    }

    public static void Print2<T>(IEnumerable<T> list, Func<int, T, string> format, 
        string separator = ", ", Func<string, string>? resultedFormat = null)
    {
        Console.WriteLine("");
        Console.WriteLine("===============================================");

        var formattedItems = new List<string>();
        for (var i = 0; i < list.Count(); i++)
        {
            var item = list.ElementAt(i);
            var formattedString = format(i, item);
            formattedItems.Add(formattedString);
        }

        var resultString = String.Join(separator, formattedItems);
        if (resultedFormat is not null)
            resultString = resultedFormat(resultString);

        Console.WriteLine(resultString);

        Console.WriteLine("===============================================");
    }
}
