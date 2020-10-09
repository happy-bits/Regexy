using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regexy.Exercises
{
    [TestClass]
    public class SearchReplace
    {
        [TestMethod]
        public void css()
        {
            var ex = new SearchReplaceExercise
            {
                Id = 1,
                Name = "CSS",
                Description = "Add spacing in the CSS",
            };

            var searchFor = @"\{(.*)\}";
            var replaceWith = "\n{\n$1\n}\n";

            var result = Engine.SearchReplace(ex, searchFor, replaceWith);
            Assert.IsTrue(result.Correct);
        }

        [TestMethod]
        public void remove_name()
        {
            /*
            
            Remove Name="...."

            E.g

                [Display(Name = "Tilldela aktiviteten till denna roll.", Order = 2)] 

            Should be:

                [Display(Order = 2)]              
             
             */
            var ex = new SearchReplaceExercise
            {
                Id = 2,
                Name = "Remove name",
                Description = "",
            };

            var searchFor = @"\(\s*Name\s*=\s*""[^""]*""[,\s]*";
            var replaceWith = "(";

            var result = Engine.SearchReplace(ex, searchFor, replaceWith);
            Assert.IsTrue(result.Correct);
        }
    }
}
