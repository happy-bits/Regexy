using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Regexy.Exercises
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void exercise1_abc()
        {

            var ex = new Exercise
            {
                Name = "ABC",
                Description = "Allow three letters in a row. The letters can be *a*, *b* or *c*.",

                Examples = new List<Example>
                {
                    new MatchExample("abc"),
                    new MatchExample("cab"),
                    new MatchExample("bca"),
                    new MatchExample("aaa"),
                    new MatchExample("ccc"),

                    new NoMatchExample("abcc"),
                    new NoMatchExample("caB"),
                    new NoMatchExample("bc"),
                    new NoMatchExample("a aa"),
                    new NoMatchExample("cccc"),
                }
            };

            string myRegexGuess = "^[abc]{3}$";

            Engine.Test(myRegexGuess, ex);
        }

        [TestMethod]
        public void exercise2_swedish_word()
        {

            var ex = new Exercise
            {
                Name = "Swedish word",
                Description = "Validate a single swedish word. Allowed chars are: a to z and å, ä, ö.",

                Examples = new List<Example>
                {
                    new MatchExample("äpple"),
                    new MatchExample("Päron"),
                    new MatchExample("PäRON"),
                    new MatchExample("traktor"),
                    new MatchExample("trAktor"),
                    new MatchExample("ö"),
                    new MatchExample("Ö"),

                    new NoMatchExample("$"),
                    new NoMatchExample("123"),
                    new NoMatchExample("trakt8r"),
                    new NoMatchExample("oscèr"),
                    new NoMatchExample(""),
                }
            };

            string myRegexGuess = "^[a-zåäöA-ZÅÄÖ]+$";

            Engine.Test(myRegexGuess, ex);
        }

        [TestMethod]
        public void exercise3_swedish_word_2()
        {

            var ex = new Exercise
            {
                Name = "Swedish word 2",
                Description = "Same but only allow uppercase on the first character",

                Examples = new List<Example>
                {
                    new MatchExample("äpple"),
                    new MatchExample("Päron"),
                    new MatchExample("traktor"),
                    new MatchExample("ö"),
                    new MatchExample("Ö"),

                    new NoMatchExample("$"),
                    new NoMatchExample("123"),
                    new NoMatchExample("trakt8r"),
                    new NoMatchExample("oscèr"),
                    new NoMatchExample("PäRON"),
                    new NoMatchExample("trAktor"),
                }
            };

            string myRegexGuess = "^([A-ZÅÄÖ]|[A-ZÅÄÖ][a-zåäö]+|[a-zåäö]+)$";

            Engine.Test(myRegexGuess, ex);
        }

        [TestMethod]
        public void exercise4_multiplication()
        {
            var ex = new Exercise
            {
                Name = "Multiplication",
                Description = "Multiplication of two numbers",

                Examples = new List<Example>
                {
                    new MatchExample("3*4"),
                    new MatchExample("7*8"),
                    new MatchExample("12*8"),
                    new MatchExample("3*5"),
                    new MatchExample("111*2222"),

                    new NoMatchExample("3a*4"),
                    new NoMatchExample("3 *4"),
                    new NoMatchExample("7#8"),
                    new NoMatchExample("12*8a"),
                    new NoMatchExample("*5"),
                    new NoMatchExample("1112222"),
                }
            };

            string myRegexGuess = @"^\d+\*\d+$";

            Engine.Test(myRegexGuess, ex);
        }

        [TestMethod]
        public void exercise5_multiplication()
        {
            var ex = new Exercise
            {
                Name = "Multiplication II",
                Description = "Same as above but allow blanks as well",

                Examples = new List<Example>
                {
                    new MatchExample("3*4"),
                    new MatchExample("7*      8"),
                    new MatchExample("12 *8"),
                    new MatchExample("  3*5"),
                    new MatchExample("   111  *   2222    "),

                    new NoMatchExample("3a*4"),
                    new NoMatchExample("7#8"),
                    new NoMatchExample("12*8a"),
                    new NoMatchExample("*5"),
                    new NoMatchExample("1112222"),
                }
            };

            string myRegexGuess = @"^\s*\d+\s*\*\s*\d+\s*$";

            Engine.Test(myRegexGuess, ex);
        }

        [TestMethod]
        public void exercise6_social_security_number()
        {
            var ex = new Exercise
            {
                Name = "Social security number",
                Description = "",

                Examples = new List<Example>
                {
                    new MatchExample("19750905-1234"),
                    new MatchExample("197509051234"),
                    new MatchExample("750905-1234"),
                    new MatchExample("750905-1234"),
                    new MatchExample("750905-1234"),

                    new NoMatchExample(" 19750905-1234"),
                    new NoMatchExample("19750905-1234 X"),
                    new NoMatchExample("AAAAAAAA-AAAA"),
                    new NoMatchExample("9750905-1234"),
                    new NoMatchExample("19750905--1234"),
                    new NoMatchExample("1975090-51234"),
                    new NoMatchExample("19750905-12344"),
                    new NoMatchExample("1975090512344"),
                    new NoMatchExample("1975090512s4"),
                    new NoMatchExample("750-905-134"),
                }
            };

            string myRegexGuess = @"^(\d{6}|\d{8})-?\d{4}$";

            Engine.Test(myRegexGuess, ex);
        }
    }
}
