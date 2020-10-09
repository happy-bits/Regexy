
using System;

namespace Regexy
{
    public class SearchReplaceExercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FileName => GetFileName(Id, "");
        public string ExpectedFileName => GetFileName(Id, "-Expected"); 
        public string ResultFileName => GetFileName(Id, "-Result");

        private string GetFileName(int id, string suffix)
        {
            string zeros = "";
            if (id < 10)
                zeros = "0";

            return $"TestFiles\\{zeros}{id}{suffix}.txt";
        }

    }
}
