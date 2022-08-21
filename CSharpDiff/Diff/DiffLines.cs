using System.Text.RegularExpressions;
using CSharpDiff.Diff.Models;
namespace CSharpDiff.Diff
{
    public class DiffLines : Diff
    {
        public new IList<DiffResult> diff(string oldString, string newString)
        {
            var cleanOldString = removeEmpty(tokenize(oldString));
            var cleanNewString = removeEmpty(tokenize(newString));
            return determineDiff(oldString, newString, cleanOldString, cleanNewString);
        }

        public new string[] tokenize(string value)
        {
            var retLines = new List<string>();
            var regex = new Regex("(\n|\r\n)");
            var linesAndNewlines = regex.Split(value).ToList();

            // Ignore the final empty token that occurs if the string ends with a new line
            if (String.IsNullOrEmpty(linesAndNewlines[linesAndNewlines.Count() - 1]))
            {
                linesAndNewlines.RemoveAt(linesAndNewlines.Count() - 1);
            }

            // Merge the content and line separators into single tokens
            for (var i = 0; i < linesAndNewlines.Count(); i++)
            {
                var line = linesAndNewlines[i];

                // if (i % 2 && !this.options.newlineIsToken)
                if (i % 2 == 1)
                {
                    retLines[retLines.Count() - 1] += line;
                }
                else
                {
                    if (IgnoreWhiteSpace)
                    {
                        line = line.Trim();
                    }
                    retLines.Add(line);
                }
            }

            return retLines.ToArray();
        }
    }

}