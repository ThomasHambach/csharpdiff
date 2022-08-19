namespace CSharpDiff.Diff.Models
{
    public class DiffResult
    {
        public string value { get; set; }
        public int? count { get; set; }
        public bool? added { get; set; }
        public bool? removed { get; set; }
        public string[] lines { get; set; }
    }
}