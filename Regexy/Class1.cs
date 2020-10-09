using System.Collections.Generic;

namespace Regexy
{
    public class Exercise
    {
        public string Name { get; set; }

        public IEnumerable<Example> Examples { get; set; }
    }

    public abstract class Example
    {
        public Example(string value) => Value = value;

        public string Value { get; set; }
    }

    public class MatchExample : Example
    {
        public MatchExample(string value) : base(value)
        {
        }
    }
    public class NoMatchExample : Example
    {
        public NoMatchExample(string value) : base(value)
        {
        }
    }
}
