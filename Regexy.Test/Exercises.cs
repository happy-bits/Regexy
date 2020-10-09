using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Regexy.Test
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
            //Engine.Test(myRegexGuess, ex, false);
        }
    }
}
