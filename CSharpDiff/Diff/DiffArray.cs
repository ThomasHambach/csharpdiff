using CSharpDiff.Diff.Models;

namespace CSharpDiff.Diff
{
    public class DiffArray : Diff
    {
        public IList<DiffResult> diff(string[] oldArray, string[] newArray)
        {
            var cleanOldString = removeEmpty(oldArray);
            var cleanNewString = removeEmpty(newArray);
            return determineDiff(cleanOldString, cleanNewString);
        }

        public new string join(string[] strings)
        {
            return "";
        }
    }
}