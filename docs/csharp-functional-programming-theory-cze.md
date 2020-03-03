# C# functional programing - cze

## Trocha teorie úvodem

Funkcionální programování je "styl" programování při kterém se klade důraz na funkce a vyhýbáme se `state mutation`.  
Dva základní koncepty:
1. Functions as first-class values

    V těchto jazycích můžete používat funkce jako vstupy alebo výstupy pro ďalší funkcie. Můžete je přiřazovat do proměnných a ukládat do kolekcí.
```
    Func<int, bool> isEven = (i) => i % 2 == 0;
    Func<int, int> pow = (i) => i * i;

    var data = Enumerable.Range(0, 10000)
        .Where(isEven)
        .Select(pow);
```
2. Avoiding state mutation

Výstup funkce závisí jen na vstupních parametrech a tato funkce nesmí měnit stav vstupních parametrů, resp. systému jako takového.

**Špatně**

```
    var nums = Enumerable.Range(-10000, 20001).Reverse().ToList();

    Action task1 = () => Console.WriteLine(nums.Sum()); //-1247 ("random number")
    Action task2 = () => { nums.Sort(); Console.WriteLine(nums.Sum()); }; //0

    Parallel.Invoke(task1, task2);
```
**Dobře**
```
var nums = Enumerable.Range(-10000, 20001).Reverse().ToList();

Action task1 = () => Console.WriteLine(nums.Sum()); //0
Action task2 = () => { Console.WriteLine(nums.OrderBy(p => p).Sum()); }; //0

Parallel.Invoke(task1, task2);
```

----
Microsoft sa snaží každou novou verzí C# více podporovat funkcionální programování.

Příklady:

https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/

1. Expression Bodied Functions and Properties
```
public bool IsSet => true;

public static int SumOfPowers(IEnumerable<int> values) => values.Select(p => p * p).Sum();
```
2. Out variables

![Out variables](https://pbs.twimg.com/media/DIdkzaJXYAAWLEG.jpg)

3. Pattern matching
```
if (node is BinaryExpression binExp)
{
    if (binExp.Left is MethodCallExpression mcExp && IsVbOperatorsExpression(mcExp))
    {
        return base.Visit(VisitVbOperatorsMethods(mcExp, binExp.NodeType));
    }
}
```

```
switch(shape)
{
    case Circle c:
        WriteLine($"circle with radius {c.Radius}");
        break;
    case Rectangle s when (s.Length == s.Height):
        WriteLine($"{s.Length} x {s.Height} square");
        break;
    case Rectangle r:
        WriteLine($"{r.Length} x {r.Height} rectangle");
        break;
    default:
        WriteLine("<unknown shape>");
        break;
    case null:
        throw new ArgumentNullException(nameof(shape));
}
```
4. Tuples
```
(string first, string middle, string last) = LookupName(id1); // deconstructing declaration
WriteLine($"found {first} {last}.");
```
5. Local Functions
```
public int Fibonacci(int x)
{
    if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
    return Fib(x).current;

    (int current, int previous) Fib(int i)
    {
        if (i == 0) return (1, 0);
        var (p, pp) = Fib(i - 1);
        return (p + pp, p);
    }
}
```
6. Using static
```
public double Circumference
   => PI * 2 * Radius;
```