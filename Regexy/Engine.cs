using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regexy
{
    public static class Engine
    {
        public static void Test(string myRegexGuess, Exercise ex, bool doAssert=true)
        {
            var results = Run(myRegexGuess, ex);

            foreach (var result in results)
            {
                
                if (result.Correct)
                {
                    Console.WriteLine($"Correct! {result.Example}");
                }
                else
                {
                    if (result.ShouldMatch)
                    {
                        Console.WriteLine($"Not correct --------> {result.Example} should match");
                    }
                    else
                    {
                        Console.WriteLine($"Not correct--------> {result.Example} should not match");
                    }
                }

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
