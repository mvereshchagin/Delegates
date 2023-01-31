namespace Delegates;

internal class Broadcaster
{
    private Action<ConsoleKeyInfo>? _keyPressedListeners;

    public void AddListener(Action<ConsoleKeyInfo> listener)
    {
        _keyPressedListeners += listener;
    }

    public void RemoveListener(Action<ConsoleKeyInfo> listener)
    {
        _keyPressedListeners -= listener;
    }

    public void Run()
    {
        while(true)
        {
            var keyInfo = Console.ReadKey();
            _keyPressedListeners?.Invoke(keyInfo); 
        }
    }
}
