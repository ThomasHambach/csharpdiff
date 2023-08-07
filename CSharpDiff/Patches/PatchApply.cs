namespace CSharpDiff.Patches
{
    public class PatchApply
    {
        public string Apply(string source, string uniDiff)
        {
            var changes = ParseUnifiedDiff(uniDiff);
            foreach (var change in changes)
            {
                source = ApplyChange(source, change);
            }
            return source;
        }

        public class Change
        {
            public string Operation { get; set; }
            public int Position { get; set; }
            public string Text { get; set; }
        }

        private List<Change> ParseUnifiedDiff(string uniDiff)
        {
            var lines = uniDiff.Split('\n');
            var changes = new List<Change>();
            foreach (var line in lines)
            {
                var parts = line.Split(' ');
                var change = new Change
                {
                    Operation = parts[0],
                    Position = int.Parse(parts[1]),
                    Text = parts[2]
                };
                changes.Add(change);
            }
            return changes;
        }

        private string ApplyChange(string source, Change change)
        {
            var lines = source.Split('\n').ToList();
            switch (change.Operation)
            {
                case "add":
                    lines.Insert(change.Position, change.Text);
                    break;
                case "delete":
                    lines.RemoveAt(change.Position);
                    break;
                case "replace":
                    lines[change.Position] = change.Text;
                    break;
            }
            
            }