namespace CSharpDiff.Diff.Models
{
    public class DiffResult
    {
        public DiffResult()
        {
            lines = new List<string>().ToArray();
            value = "";
        }

        public string value { get; set; }
        public int count { get; set; } = 0;
        public bool? added { get; set; }
        public bool? removed { get; set; }
        public string[] lines { get; set; }
    }
}