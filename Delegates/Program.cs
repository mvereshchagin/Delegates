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

TestFiltering();

void TestFiltering()
{
    string[] names = { "Petya", "Oleg", "Polina", "Evgeny", "Anna", "Sofia", "Marat"};
    // var newNames = CollectionUtils<string>.DoFilter(names, (item) => item.Length <= 4);
    var newNames = CollectionUtils<string>.DoFilter(names, LengthNotMoreThan4Filter);
    foreach (var name in newNames)
        Console.WriteLine(name);

    Console.WriteLine("=======================================");

    var newNames2 = CollectionUtils<string>.DoFilter(names, NameStartFromPFilter);
    foreach (var name in newNames2)
        Console.WriteLine(name);

    Console.WriteLine("=======================================");

    int[] numbers = { 1, 34, 22, 32, 11, 23, 44, 58, 76, 32, 21, 9 };
    // var newNumbers = CollectionUtils<int>.DoFilter(numbers, EvenFilter);
    var newNumbers = CollectionUtils<int>.DoFilter(numbers, (i) => i % 2 == 0);
    foreach (var number in newNumbers)
        Console.WriteLine(number);
}

bool LengthNotMoreThan4Filter(string name) => name.Length <= 4;
bool NameStartFromPFilter(string name) => name.StartsWith("P");
bool EvenFilter(int number) => number % 2 == 0;


// тип данных, соответствующий любой функции с одним аргументом string и ничего не возвращающей
delegate void SendMessage(string text);

delegate double Operation(double x, double y);
