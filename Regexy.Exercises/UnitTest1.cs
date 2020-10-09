using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Regexy.Exercises
{
    [TestClass]
    public class Exercises
    {
        [TestMethod]
        public void abc()
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
        public void swedish_word()
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
        public void swedish_word_2()
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
    }
}
