namespace Regexy.Test
{
    public class Result
    {
        public string Try { get; internal set; }
        public bool IsMatch { get; internal set; }
        public bool ShouldMatch { get; internal set; }
        public bool Correct => IsMatch == ShouldMatch;

        public string Example { get; internal set; }
    }
}
