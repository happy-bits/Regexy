namespace Regexy
{
    public abstract class Example
    {
        public Example(string value) => Value = value;

        public string Value { get; set; }
    }
}
