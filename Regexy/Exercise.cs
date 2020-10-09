using System.Collections.Generic;

namespace Regexy
{
    public class Exercise
    {
        public string Name { get; set; }

        public IEnumerable<Example> Examples { get; set; }
        public string Description { get; set; }
    }
}
