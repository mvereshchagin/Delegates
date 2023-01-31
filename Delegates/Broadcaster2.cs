namespace Delegates;

internal class Broadcaster2
{
    public class KeyPressedEventArgs : EventArgs
    {
        public ConsoleKeyInfo KeyInfo { get; init; }

        public KeyPressedEventArgs(ConsoleKeyInfo keyInfo)
        {
            KeyInfo = keyInfo;
        }
    }

    // обработчик события, но такой вариант лучше не использовать
    // public delegate void KeyPressedHandler();

    // стандартная структра обработчкиа события
    // public delegate void KeyPressedHandler(object sender, EventArgs args);

    // делегат с пользовательской информацией о событии
    // public delegate void KeyPressedHandler(object sender, KeyPressedEventArgs args);

    // определение события
    // Знак "?" означает, что к событию может быть никто не подключен
    // public event KeyPressedHandler? KeyPressed;
    //private event KeyPressedHandler? _keyPressed;
    //public event KeyPressedHandler? KeyPressed
    //{
    //    add
    //    {
    //        _keyPressed += value;
    //        Console.WriteLine("New listener has been added");
    //    }
    //    remove
    //    {
    //        if(_keyPressed is not null)
    //            _keyPressed -= value;
    //        Console.WriteLine("Listener has been removed");
    //    }
    //}

    private event EventHandler<KeyPressedEventArgs>? _keyPressed;
    public event EventHandler<KeyPressedEventArgs>? KeyPressed
    {
        add
        {
            _keyPressed += value;
            Console.WriteLine("New listener has been added");
        }
        remove
        {
            if (_keyPressed is not null)
                _keyPressed -= value;
            Console.WriteLine("Listener has been removed");
        }
    }

    public void Run()
    {
        while (true)
        {
            var keyInfo = Console.ReadKey();
            // _keyPressed?.Invoke(this, new EventArgs());
            // _keyPressed?.Invoke(this, new KeyPressedEventArgs(keyInfo));
            OnKeyPressed(keyInfo);
        }
    }

    public void OnKeyPressed(ConsoleKeyInfo keyInfo)
    {
        _keyPressed?.Invoke(this, new KeyPressedEventArgs(keyInfo));
    }
}
