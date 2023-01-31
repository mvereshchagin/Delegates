using Delegates;

void SendGreeting(string name)
{
    Console.WriteLine($"Hello, {name}");
}

void SayGoodbye(string name)
{
    Console.WriteLine($"Goodbye, {name}");
}

// присваивание значения делегату
SendMessage msg = SendGreeting;
// добавление метода
msg += SayGoodbye;
// высызваются оба
msg("Vasya");

msg -= SendGreeting;
msg("Polina");

SendMessage msg2 = null;
if(msg2 != null)
    msg2("Oleg");

SendMessage msg3 = (text) => Console.WriteLine($"What an intersting text: {text}");
msg3("Something");

msg2?.Invoke("Alexei");

double Sum(double x, double y) => x + y;
double Multiply(double x, double y) => x * y;

Operation op = Sum;
var res = op?.Invoke(1d, 3d);
op = Multiply;
var res2 = op?.Invoke(1d, 2d);

// TestFiltering();
// TestBroadcaster();
// TestBroadcasterWithEvents();
TestPropertyChanged();


void TestFiltering()
{
    string[] names = { "Petya", "Oleg", "Polina", "Evgeny", "Anna", "Sofia", "Marat"};
    // var newNames = CollectionUtils<string>.DoFilter(names, (item) => item.Length <= 4);
    var newNames = CollectionUtils.DoFilter<string>(names, LengthNotMoreThan4Filter);
    foreach (var name in newNames)
        Console.WriteLine(name);

    Console.WriteLine("=======================================");

    var newNames2 = CollectionUtils.DoFilter<string>(names, NameStartFromPFilter);
    foreach (var name in newNames2)
        Console.WriteLine(name);

    Console.WriteLine("=======================================");

    int[] numbers = { 1, 34, 22, 32, 11, 23, 44, 58, 76, 32, 21, 9 };
    // var newNumbers = CollectionUtils<int>.DoFilter(numbers, EvenFilter);
    var newNumbers = CollectionUtils.DoFilter2<int>(numbers, (i) => i % 2 == 0);
    foreach (var number in newNumbers)
        Console.WriteLine(number);

    CollectionUtils.Print<string>(names, (name) => $"Client: {name}");

    CollectionUtils.Print2<string>(names, (i, name) => $"Client {i}: {name}");

    CollectionUtils.Print2<int>(numbers, (i, number) => $"numbers[{i}] = {number}");

    CollectionUtils.Print2<int>(numbers, (i, number) => $"{number}", resultedFormat: (str) => $"[{str}]");

    CollectionUtils.Print2<string>(names, (i, name) => $"{i}: {name}", 
        resultedFormat: (str) => $"[{str}]", separator: "; ");


    var namesCol = new NamesCollection2() { "Name1", "Name2", "Name3", "Name4", "Name5", "Name6" };
    Console.WriteLine(namesCol);

    Console.WriteLine("***************************************************************");

    var namesCol3 = new NamesCollection3() { "Name1", "Name2", "Name3", "Name4", "Name5", "Name6" };
    namesCol3.Format = (str) => $"array: [{str}]";
    Console.WriteLine(namesCol3);

    ActionUtils.PrintActionExecTime("Sleep3", (args) => Thread.Sleep(3000));
}

bool LengthNotMoreThan4Filter(string name) => name.Length <= 4;
bool NameStartFromPFilter(string name) => name.StartsWith("P");
bool EvenFilter(int number) => number % 2 == 0;

void TestBroadcaster()
{
    var broadcaster = new Broadcaster();
    broadcaster.AddListener(
        (keyInfo) => Console.WriteLine($"{DateTime.Now.ToString("yyy.MM.dd hh:mm:ss")} {keyInfo.Key}"));
    broadcaster.AddListener((keyInfo) => 
    {
        using var writer = File.AppendText("keys.txt");
        writer.WriteLine($"{DateTime.Now.ToString("yyy.MM.dd hh:mm:ss")} {keyInfo.Key}");
    });
    broadcaster.AddListener((keyInfo) =>
    {
        if (keyInfo.Key == ConsoleKey.Escape)
            Console.WriteLine("Are you expected to stop the app by pressing 'Esc'. You are failed, bro!");
    });

    broadcaster.Run();
}

void TestBroadcasterWithEvents()
{
    var broadcaster = new Broadcaster2();
    broadcaster.KeyPressed += OnKeyPressed;
    broadcaster.KeyPressed -= OnKeyPressed;
    broadcaster.KeyPressed += OnKeyPressed;
    broadcaster.KeyPressed += (sender, args) =>
    {
        Console.WriteLine($"anonymous listener heard KeyPressed event: {args.KeyInfo.Key}");
    };
    broadcaster.Run();
}

void OnKeyPressed(object sender, EventArgs e)
{
    Console.WriteLine("OnKeyPressed listener heard KeyPressed event");
}

void TestPropertyChanged()
{
    var car1 = new Car() { Model = "x6", Producer = "BMW", YearOfCreate = 2020 };
    car1.PropertyChanged += (sender, args) =>
    {
        Console.WriteLine($"Car \"{sender}\" has changed property \"{args.PropertyName}\"");
    };
    car1.Model = "x5";
    car1.YearOfCreate = 2018;
    car1.Producer = "Lada";
    car1.Model = "Kalina";
}


// тип данных, соответствующий любой функции с одним аргументом string и ничего не возвращающей
delegate void SendMessage(string text);

delegate double Operation(double x, double y);
