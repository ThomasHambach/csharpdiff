namespace CSharpDiff.Diff.Models
{
    public class Hunk
    {
        public int oldStart { get; set; }
        public int oldLines { get; set; }
        public int newStart { get; set; }
        public int newLines { get; set; }
        public string[] lines { get; set; }
    }
}