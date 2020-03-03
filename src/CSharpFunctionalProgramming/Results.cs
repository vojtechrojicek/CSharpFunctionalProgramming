using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpFunctionalPrograming
{
    public static class Results
    {
        public static string ReverseSentence(this string value) =>
            string.Join(" ", value.Split(' ').Reverse());

        public static string ToTitleCase(this string value) =>
            string.Join(" ", value.Split(' ').Select(p => $"{char.ToUpper(p[0])}{p.Substring(1)}"));

        public static string Accum(this string value) =>
            string.Join("-",
                value.Select((c, i) => $"{char.ToUpper(c)}{new String(char.ToLower(c), i)}"));

        public static string HighAndLow(this string value)
        {
            Func<string, IEnumerable<int>> parse = (t) => t.Split(' ').Select(c => int.Parse(c));

            return $"{parse(value).Max()} {parse(value).Min()}";
        }

        public static char FindMissingLetter(this string chars) =>
            (char)Enumerable.Range((int)chars.First(), chars.Length)
            .FirstOrDefault(p => !chars.Contains((char)p));

        public static IEnumerable<(int number, int count)> GroupByWithCount(this IEnumerable<int> value) =>
            value
            .GroupBy(p => p)
            .Select(p => (number: p.Key, count: p.Count()))
            .OrderBy(p => p.number);

        public static int SumOfPowers(this int number) =>
            Enumerable.Range(1, number).Sum(p => p * p);

        public static int DescendingNumber(this int number) =>
            int.Parse(
                string.Join("",
                    number.ToString()
                    .Select(p => int.Parse(p.ToString()))
                    .OrderByDescending(p => p)));

        public static IEnumerable<int> MultiplicationTable(this IEnumerable<int> numbers1, IEnumerable<int> numbers2) =>
            numbers1.Zip(numbers2, (n1, n2) => n1 * n2);

        public static string LongestConsec(this IEnumerable<string> s, int k) =>
            s.Count() < k || k <= 0 ? string.Empty :
            Enumerable.Range(0, s.Count() - k + 1)
            .Select(x => string.Join("", s.Skip(x).Take(k)))
            .OrderByDescending(p => p.Length)
            .First();

        public static IEnumerable<string> TowerBuilder(this int number) =>
            Enumerable.Range(1, number)
            .Select(p => $"{new string(' ', number - p)}{new string('*', (p * 2 - 1))}{new string(' ', number - p)}");

        public static bool ValidParentheses(this string value) =>
            Enumerable
            .Range(0, value.Length)
            .All(i => value[i] == '(' ? value.SkipWhile(c => c != ')').FirstOrDefault() == ')' : true) &&
            Enumerable
            .Range(0, value.Length).Reverse()
            .All(i => value[i] == ')' ? value.TakeWhile(c => c == '(').LastOrDefault() == '(' : true);

        public static IEnumerable<int> GenerateRandom(this int count) =>
            Enumerable.Range(0, count).Select((p) => new Random().Next());

        public static IEnumerable<Person> MapNamesToPeople(this IEnumerable<string> names) =>
            names.Select(p => new Person() { Name = p });

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> values, Predicate<T> predicate)
        {
            foreach (var item in values)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> values) where T : IComparable
        {
            if (values == null || !values.Any())
            {
                return new List<T>();
            }
            var firstElement = values.First();
            var rest = values.Skip(1);

            var smallerElements = rest
                .Where(i => i.CompareTo(firstElement) < 0)
                .QuickSort();

            var largerElements = rest
                .Where(i => i.CompareTo(firstElement) >= 0)
                .QuickSort();

            return smallerElements
                .Concat(new List<T> { firstElement })
                .Concat(largerElements);
        }

        public static IEnumerable<T> QuickSort2<T>(this IEnumerable<T> values) where T : IComparable =>
            values == null || !values.Any() ? new List<T>() :
            values.Skip(1)
            .SmallerThen(values.First())
            .Concat(new List<T> { values.First() })
            .Concat(values.Skip(1).LargerThen(values.First()));

        public static IEnumerable<T> SmallerThen<T>(this IEnumerable<T> values, T firstElement) where T : IComparable =>
            values
            .Where(i => i.CompareTo(firstElement) < 0)
            .QuickSort2();

        public static IEnumerable<T> LargerThen<T>(this IEnumerable<T> values, T firstElement) where T : IComparable =>
            values
            .Where(i => i.CompareTo(firstElement) >= 0)
            .QuickSort2();
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
