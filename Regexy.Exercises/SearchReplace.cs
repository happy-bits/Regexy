using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            
            Remove:
            
                Name="...."

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

            // Alternativ lösning

            var searchForAlternative = @"\(\s*Name\s*=\s*"".*?""[,\s]*";  // non greedy
            var result2 = Engine.SearchReplace(ex, searchForAlternative, replaceWith);
            Assert.IsTrue(result2.Correct);

        }

        [TestMethod]
        public void remove_required()
        {
            /*
            
                Remove 
                
                    [Required(...)]

                E.g replace this

                        [Display(Name = "Tilldela aktiviteten till denna roll.", Order = 2)]
                        [Required(AllowEmptyStrings = false)]
                        [Enum(typeof(Enums.AssignedActivityRole))]

                with this

                        [Display(Name = "Tilldela aktiviteten till denna roll.", Order = 2)]
                        [Enum(typeof(Enums.AssignedActivityRole))]


                Answer

                    Search      \n\s*\[Required\(.*\)\]\s*
                    Replace

         
             
             */
            var ex = new SearchReplaceExercise
            {
                Id = 3,
                Name = "Remove required",
                Description = "",
            };

            var searchFor = @"\[Required\(.*\)\]\s*\n\s*"; 
            var replaceWith = "";

            var result = Engine.SearchReplace(ex, searchFor, replaceWith);
            Assert.IsTrue(result.Correct);
        }
    }
}
