using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CSharpFunctionalProgramming
{
    public static class NonFunctionalExample
    {
        [Fact]
        public static void ReverseSentenceTest()
        {
            "Bob has dog".ReverseSentence().Should().Be("dog has Bob");
        }

        public static string ReverseSentence(this string sentense)
        {
            var words = new List<string>();
            string word = string.Empty;
            foreach (char letter in sentense)
            {
                if (letter != ' ')
                {
                    word += letter;
                }
                else
                {
                    words.Add(word);
                    word = string.Empty;
                }
            }
            words.Add(word);

            var result = new StringBuilder();
            for (int i = (words.Count - 1); i >= 0; i--)
            {
                result.Append(words[i]);
                if (i != 0)
                {
                    result.Append(" ");
                }
            }

            return result.ToString();
        }
    }
}
