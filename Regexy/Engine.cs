using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
                    var not = result.ShouldMatch ? " not" : "";

                    Console.WriteLine($"Not correct --------> {result.Example}{not} should match");
                }

                if (doAssert)
                {
                    Assert.IsTrue(result.Correct);
                }
            }
        }

        public static SearchReplaceResult SearchReplace(SearchReplaceExercise ex, string searchFor, string replaceWith)
        {
            var input = File.ReadAllText(ex.FileName).Replace("\r\n", "\n");
            var expected = File.ReadAllText(ex.ExpectedFileName).Replace("\r\n", "\n");

            var replacedText = Regex.Replace(input, searchFor, replaceWith);

            File.WriteAllText(ex.ResultFileName, replacedText);

            return new SearchReplaceResult
            {
                Input = input,
                Expected = expected,
                ReplacedText = replacedText
            };
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
