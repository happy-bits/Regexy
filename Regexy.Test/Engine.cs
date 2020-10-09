using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regexy.Test
{
    public static class Engine
    {
        internal static void Test(string myRegexGuess, Exercise ex, bool doAssert=true)
        {
            var results = Run(myRegexGuess, ex);

            foreach (var result in results)
            {
                var correct = result.Correct ? "Correct" : "NotCorrect";
                var shouldMatch = result.ShouldMatch ? "ShouldMatch" : "ShouldNotMatch";
                var ismatch = result.IsMatch ? "IsMatch" : "NoMatch";
                var example = result.Example;

                Console.WriteLine($"{correct,-30}{shouldMatch,-30}{ismatch,-30}{example,-30}");

                if (doAssert)
                {
                    Assert.IsTrue(result.Correct);
                }
            }
        }

        private static IEnumerable<Result> Run(string myRegexGuess, Exercise ex)
        {
            var results = new List<Result>();
            foreach (var shouldMatch in ex.Examples)
            {
                var result = new Result
                {
                    Try = shouldMatch.Value,
                    IsMatch = Regex.IsMatch(shouldMatch.Value, myRegexGuess),
                    ShouldMatch = shouldMatch is MatchExample,
                    Example = shouldMatch.Value
                };
                results.Add(result);
            }

            return results;
        }


    }
}
