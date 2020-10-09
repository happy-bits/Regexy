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
                Description = "Validate a single swedish word. Allowed chars are: a to z and �, �, �.",

                Examples = new List<Example>
                {
                    new MatchExample("�pple"),
                    new MatchExample("P�ron"),
                    new MatchExample("P�RON"),
                    new MatchExample("traktor"),
                    new MatchExample("trAktor"),
                    new MatchExample("�"),
                    new MatchExample("�"),

                    new NoMatchExample("$"),
                    new NoMatchExample("123"),
                    new NoMatchExample("trakt8r"),
                    new NoMatchExample("osc�r"),
                    new NoMatchExample(""),
                }
            };

            string myRegexGuess = "^[a-z���A-Z���]+$";

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
                    new MatchExample("�pple"),
                    new MatchExample("P�ron"),
                    new MatchExample("traktor"),
                    new MatchExample("�"),
                    new MatchExample("�"),

                    new NoMatchExample("$"),
                    new NoMatchExample("123"),
                    new NoMatchExample("trakt8r"),
                    new NoMatchExample("osc�r"),
                    new NoMatchExample("P�RON"),
                    new NoMatchExample("trAktor"),
                }
            };

            string myRegexGuess = "^([A-Z���]|[A-Z���][a-z���]+|[a-z���]+)$";

            Engine.Test(myRegexGuess, ex);
        }
    }
}
