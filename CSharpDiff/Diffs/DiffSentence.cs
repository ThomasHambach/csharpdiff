using System.Text.RegularExpressions;
using CSharpDiff.Diffs.Models;

namespace CSharpDiff.Diffs
{
    public class DiffSentence : Diff
    {
        public new IList<DiffResult> diff(string oldString, string newString)
        {
            var cleanOldString = removeEmpty(tokenize(oldString));
            var cleanNewString = removeEmpty(tokenize(newString));
            return determineDiff(cleanOldString, cleanNewString);
        }

        public new string[] tokenize(string value)
        {
            var regex = new Regex(@"(\S.+?[.!?])(?=\s+|$)");
            return regex.Split(value);
        }
    }
}