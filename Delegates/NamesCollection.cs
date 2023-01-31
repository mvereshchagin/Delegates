namespace Delegates;

internal class NamesCollection : List<string>
{
    public override string ToString()
    {
        List<string> items = new();
        foreach(var item in this)
        {
            var formattedItem = $"{item}";
            items.Add(item);
        }

        return $"[ {String.Join(", ", items)} ]";
    }
}

internal class NamesCollection2 : NamesCollection
{
    public override string ToString()
    {
        List<string> items = new();
        foreach (var item in this)
        {
            var formattedItem = $"{item}";
            items.Add(item);
        }

        return $"( {String.Join(", ", items)} )";
    }
}

public class NamesCollection3 : List<string>
{
    public Func<string, string>? ItemFormat { get; set; }

    public Func<string, string>? Format { get; set; }

    public override string ToString()
    {
        ItemFormat ??= (name) => name;
        Format ??= (str) => str;

        List<string> items = new();
        foreach(var item in this)
        {
            var str = ItemFormat(item);
            items.Add(str);
        }

        return $"{Format(String.Join(", ", items))}";
    }
}
