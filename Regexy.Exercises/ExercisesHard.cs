using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Regexy.Exercises
{
    [TestClass]
    public class ExercisesHard
    {
        [TestMethod]
        public void exercise1_bob()
        {
            /*
            Expected three letters but not the word "bob"

            Create two solutions: use **negative lookbehind** and **negative lookahead**
            
             */
            var ex = new Exercise
            {
                Examples = new List<Example>
                {
                    new MatchExample("bab"),
                    new MatchExample("boa"),
                    new MatchExample("aob"),
                    new MatchExample("zzz"),
                    new MatchExample("xxx"),

                    new NoMatchExample("bob"),
                    new NoMatchExample("ab"),
                    new NoMatchExample("a"),
                }
            };

            string myRegexGuess_Ahead = "^(?!bob)[a-z]{3}$";     // "negative lookahead"
            string myRegexGuess_Behind = "^[a-z]{3}(?<!bob)$";   // "negative lookbehind"

            Engine.Test(myRegexGuess_Ahead, ex);
            Engine.Test(myRegexGuess_Behind, ex);

            /*
               Explanation:

                (?!AAA) ==> what comes next should not match AAA  
                (?<!AAA) ==>  what came before should not match AAA             
            */
        }

    }
}
