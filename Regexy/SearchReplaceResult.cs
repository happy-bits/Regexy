namespace Regexy
{
    public class SearchReplaceResult
    {
        public string Input { get; internal set; }
        public string Expected { get; internal set; }
        public string ReplacedText { get; internal set; }
        public bool Correct => ReplacedText == Expected;
    }
}
