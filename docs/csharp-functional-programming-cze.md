
# C# functional programing - cze

## Zadání

1. Napišme funkci, která dostane na vstupu větu a vráti větu, v které bude otočené pořadí slov.
Pro jednoduchost berme, že oddělovač slov je jen mezera a neřešíme velikost písmen.
```
"Bob has dog" => "dog has Bob"
```
2. Napište funkci, která každému písmenu ve větě změní první písmeno na velké.
```
"How can mirrors be real if our eyes aren't real" =>
        "How Can Mirrors Be Real If Our Eyes Aren't Real"

//Bez použití CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
```
3. Napište funkci, která znásobí text, který dostane na vstupu podle patternu:
```
"abcd" => "A-Bb-Ccc-Dddd"
```
4. Napište funkci, která z textu vybere nejnižší a najvyšší číslo.
Předpokládejme, že tam budou jen celá čísla a jejich oddělovač je mezera.
```
"8 3 -5 42 -1 0 0 -9 4 7 4 -4" => "42 -9"
```
 5. Napište funkci, která najde v posloupnosti znaků ten, který tam chýbí.
 Předpokládejme, že vždy chýbí jen jeden znak a že jdou postupně.
```
"abcefgh" => 'd'
"EFHI" => 'G'
```
6. Máme pole čísel s duplicitami.
Napište funkci, která je seřadí vzestupně podle čísla a přidá k ním i jejich četnosti.
```
{ 1, 2, 5, 4, 1, 3, 8, 1, 4, 5, 8, 4 } =>
  {(1, 3), (2, 1), (3, 1), (4, 3), (5, 2), (8, 2)}
```
7. Napište funkci, která spočíta mocniny čísel od 1 po zvolené číslo.
```
50 => 42925
100 => 338350
```
8. Napište funkci, která vytvoří nové číslo z původního tak, že číslice budou sestupné.
```
214123154 => 544322111
```
9. Napište funkci, která vynásobi mezi sebou hodnoty dvoch kolekcí.
V kolekcích nemusí býr stejný počet čísel.
```
{2, 4, 9, 11 } x { 10, 12, 13, 15, 22 } => {20, 48, 117, 165}
```
10. Napište funkci, která ma vstupní parametry `pole stringů` a číslo `k`.
Naší úlohou je vrátit první nejdelší řetězec sestavený z `k` po sobě jdoucích řetězců v poli.
Pokud `n = 0 or k > n or k <= 0 return string.Empty`
```
{ "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" } |> 2 => "abigailtheta"
{ "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" } |> 1 => "oocccffuucccjjjkkkjyyyeehh"
{ "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" } |> 2 => "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck"
{ "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" } |> 2 => "wlwsasphmxxowiaxujylentrklctozmymu"
{ "zone", "abigail", "theta", "form", "libe", "zas" } |> -2 => ""
{ "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" } |> 3 => "ixoyx3452zzzzzzzzzzzz"
```
11. Trocha hraní :)

Napište TowerBuilder.  
Funkci, které zadáme výšku budovy a ona nám vráti jednotlivé poschodí.

```
6 =>
[
  '     *     ',
  '    ***    ',
  '   *****   ',
  '  *******  ',
  ' ********* ',
  '***********'
]
```

12. Napište funkci, která zvaliduje vstupní string, jestli obsahuje správně ozávorkované výrazy.

```
"()" => true
")(()))" => false
"(" => false
"(())((()())())" => true
")((((" => false
"))))))" => false
"(((())))" => true
"((((" => false
```

13. Napište funkci, která vygeneruje zadaný počet náhodných čísel.

```
5 => {45, 78, 658, 154, 87}
```

14. Napište funkci, která přemapuje seznam jmen na seznam osob.

```
{ "Zaynab", "Benn", "Sophie", "Emmanuella", "Terrence" } =>
{ Person("Zaynab"), Person("Benn"), Person("Sophie"), Person("Emmanuella"), Person("Terrence") }
```

15. Napište vlastní implementaci LINQové `Where` metody.

(Ukázka pro sudá čísla: `x % 2 == 0`)
```
{ 1, 2, 3, 4, 5, 6, 7, 8 } =>
  { 2, 4, 6, 8 }
```

16. Teď si zkuste napsat odlehčenou verzi quicksort-u.

Klasickým imperatívním způsobem programování by to mohlo vypadat takto:
```
public static List<T> QuickSort<T>(List<T> values) where T : IComparable
{
    if (values.Count == 0)
    {
        return new List<T>();
    }

    T firstElement = values[0];

    var smallerElements = new List<T>();
    var largerElements = new List<T>();
    for (int i = 1; i < values.Count; i++)
    {
        var elem = values[i];
        if (elem.CompareTo(firstElement) < 0)
        {
            smallerElements.Add(elem);
        }
        else
        {
            largerElements.Add(elem);
        }
    }

    var result = new List<T>();
    result.AddRange(QuickSort(smallerElements.ToList()));
    result.Add(firstElement);
    result.AddRange(QuickSort(largerElements.ToList()));

    return result;
}
```

My to zkusme napsat "funkcionálně" jako extension na `IEnumerable<T>`.
Pokusme sa co najvíc eliminovat kód highlevel funkce.

```
{ 2, 8, 1, 4, 6, 9, 8, 7, 2, 45, 98, 41, 32, 23, 7 } =>
  { 1, 2, 2, 4, 6, 7, 7, 8, 8, 9, 23, 32, 41, 45, 98 }
```

----
PS: Takto by to mohlo vypadat např. v jazyku F#, který je od začátku hlavně funkcionálním jazykem. :-)

```
let rec quicksort = function
   | [] -> []
   | first::rest ->
        let smaller, larger = List.partition ((>=) first) rest
        List.concat [quicksort smaller; [first]; quicksort larger]
```