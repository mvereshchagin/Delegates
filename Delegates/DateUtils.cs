namespace Delegates;

internal class ActionUtils
{
    public static void PrintActionExecTime(string funcName, Action<object?> action, object? args = null)
    {
        var start = DateTime.Now;
        action(args);
        Console.WriteLine($"{funcName} execution time: {(DateTime.Now - start).TotalMilliseconds}");
    }
}
