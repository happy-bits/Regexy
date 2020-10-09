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

        [TestMethod]
        public void exercise2_no_bob_inside()
        {
            var ex = new Exercise
            {
                Description= "Don't allow 'bob' inside of text",

                Examples = new List<Example>
                {
                    new MatchExample("aaaaaaaa"),
                    new MatchExample("bbbbbbb"),
                    new MatchExample("abcdefgh"),
                    new MatchExample("aaabooaaaaa"),
                    new MatchExample("aaaaaboooo"),

                    new NoMatchExample("bob"),
                    new NoMatchExample("aaabobaaaaa"),
                    new NoMatchExample("bbbbobbb"),
                    new NoMatchExample("abbobcdefgh"),
                    new NoMatchExample("bobaaaaa"),
                    new NoMatchExample("aaaaabob"),
                }
            };

            string myRegexGuess = "^(?!.*bob.*)[a-z]+$"; 

            Engine.Test(myRegexGuess, ex);

        }

        [TestMethod]
        public void exercise3_five_letters()
        {
            // Hint: use "positive lookahead"
            var ex = new Exercise
            {
                Description = "Five letters (a-z). One of the letters has to be an 'a'",

                Examples = new List<Example>
                {
                    new MatchExample("aaaaa"),
                    new MatchExample("aaaay"),
                    new MatchExample("waaaa"),
                    new MatchExample("aeagw"),
                    new MatchExample("aeagw"),
                    new MatchExample("aazeq"),
                    new MatchExample("zaare"),
                    new MatchExample("rwgea"),
                    new MatchExample("qaqfq"),

                    new NoMatchExample("aaa"),
                    new NoMatchExample("aaaa"),
                    new NoMatchExample("aaaa1"),
                    new NoMatchExample("1aaaa"),
                    new NoMatchExample("yyyyy"),
                    new NoMatchExample("wwtrr"),
                    new NoMatchExample("qeegw"),
                    new NoMatchExample("weegw"),
                    new NoMatchExample("sfzeq"),
                    new NoMatchExample("ztyre"),
                    new NoMatchExample("rwgee"),
                    new NoMatchExample("qdffr"),
                }
            };

            string myRegexGuess = "^(?=.*a)[a-z]{5}$";
            string myRegexGuess_Alternative = "^(?=[a-z]{5})(?=.*a).*$";
            
            Engine.Test(myRegexGuess, ex);
            Engine.Test(myRegexGuess_Alternative, ex);

            /*
             
            Explanation

                (?=.*a)   ==> look ahead. Must contain an "a"
                [a-z]{5}  ==> must have five letters             
             */

        }

    }
}
