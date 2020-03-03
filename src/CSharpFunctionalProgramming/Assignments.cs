using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CSharpFunctionalPrograming
{
    public class Tests
    {
        [Fact]
        public static void ReverseSentenceTest()
        {
            "Bob has dog".ReverseSentence().Should().Be("dog has Bob");
        }

        [Fact]
        public static void ToTitleCaseTest()
        {
            "How can mirrors be real if our eyes aren't real"
            .ToTitleCase()
                .Should()
                .Be("How Can Mirrors Be Real If Our Eyes Aren't Real");

            // Do not use CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }

        [Fact]
        public static void AccumTest()
        {
            "abcd"
            .Accum()
                .Should()
                .Be("A-Bb-Ccc-Dddd");
        }

        [Fact]
        public static void HighAndLowTest()
        {
            "8 3 -5 42 -1 0 0 -9 4 7 4 -4"
            .HighAndLow()
                .Should()
                .Be("42 -9");
        }

        [Fact]
        public static void FindMessingLetterTest()
        {
            "abcefgh"
            .FindMissingLetter()
                .Should().Be('d');

            "EFHI"
            .FindMissingLetter()
                .Should().Be('G');
        }

        [Fact]
        public void GroupByWithCountShould()
        {
            new int[] { 1, 2, 5, 4, 1, 3, 8, 1, 4, 5, 8, 4 }
                .GroupByWithCount()
                .Should().BeEquivalentTo(
                    new List<(int, int)>()
                    {
                        (1, 3), (2, 1), (3, 1), (4, 3), (5, 2), (8, 2)
                    });
        }

        [Fact]
        public void SumOfPowersTest()
        {
            50.SumOfPowers()
                .Should().Be(42925);

            100.SumOfPowers()
                .Should().Be(338350);
        }

        [Fact]
        public void DescendingNumberTest()
        {
            214123154
                .DescendingNumber()
                .Should()
                .Be(544322111);
        }

        [Fact]
        public void MultiplicationTableTest()
        {
            var numbers1 = new List<int>() { 2, 4, 9, 11 };
            var numbers2 = new List<int>() { 10, 12, 13, 15, 22 };

            numbers1.MultiplicationTable(numbers2)
                .Should().BeEquivalentTo(new List<int>() { 20, 48, 117, 165 });
        }

        [Fact]
        public void LongestConsecTest()
        {
            new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }
                .LongestConsec(2)
                .Should().Be("abigailtheta");
            new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }
                .LongestConsec(1)
                .Should().Be("oocccffuucccjjjkkkjyyyeehh");
            new String[] { }.LongestConsec(3).Should().BeEmpty();
            new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }
                .LongestConsec(2)
                .Should().Be("wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }
                .LongestConsec(2)
                .Should().Be("wlwsasphmxxowiaxujylentrklctozmymu");
            new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }
                .LongestConsec(-2)
                .Should().BeEmpty();
            new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }
                .LongestConsec(3)
                .Should().Be("ixoyx3452zzzzzzzzzzzz");
        }

        [Fact]
        public void TowerBuilderTest()
        {
            1.TowerBuilder()
                .Should().BeEquivalentTo(new List<string>() { "*" });

            2.TowerBuilder()
                .Should().BeEquivalentTo(new List<string>() { " * ", "***" });

            3.TowerBuilder()
                .Should().BeEquivalentTo(new List<string>() { "  *  ", " *** ", "*****" });

            4.TowerBuilder()
                .Should().BeEquivalentTo(new List<string>() { "   *   ", "  ***  ", " ***** ", "*******" });
        }

        [Fact]
        public void ValidParenthesesTest()
        {
            "()".ValidParentheses().Should().BeTrue();
            ")(()))".ValidParentheses().Should().BeFalse();
            "(".ValidParentheses().Should().BeFalse();
            "(())((()())())".ValidParentheses().Should().BeTrue();
            ")((((".ValidParentheses().Should().BeFalse();
            "))))))".ValidParentheses().Should().BeFalse();
            "(((())))".ValidParentheses().Should().BeTrue();
            "((((".ValidParentheses().Should().BeFalse();
            "(((((f)))))".ValidParentheses().Should().BeTrue();
        }

        [Fact]
        public void MapPeopleTest()
        {
            var names = new List<string>() { "Zaynab", "Benn", "Sophie", "Emmanuella", "Terrence" };

            var people = names.MapNamesToPeople();

            people.Select(p => p.Name)
                .Should().BeEquivalentTo(names);
        }

        [Fact]
        public void FilterTest()
        {
            Predicate<int> isEven = p => p % 2 == 0;

            new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }
                .Filter(isEven)
                .Should().BeEquivalentTo(new List<int>() { 2, 4, 6, 8 });
        }

        [Fact]
        public void QuickSortTest()
        {
            var data = new List<int>() { 2, 8, 1, 4, 6, 9, 8, 7, 2, 45, 98, 41, 32, 23, 7 };

            data.QuickSort2()
                .Should().BeEquivalentTo(new List<int>() { 1, 2, 2, 4, 6, 7, 7, 8, 8, 9, 23, 32, 41, 45, 98 });
        }
    }
}
