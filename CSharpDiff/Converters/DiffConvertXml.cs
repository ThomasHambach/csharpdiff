using System.Web;
using CSharpDiff.Diffs.Models;

namespace CSharpDiff.Converters
{
    public static class DiffConvertXml
    {
        /// <summary>
        /// Convert the changes to an XML structure
        /// </summary>
        /// <param name="changes"></param>
        /// <returns></returns>
        public static string Convert(IList<DiffResult> changes)
        {

            var ret = new List<string>();
            for (var i = 0; i < changes.Count; i++)
            {
                var change = changes.ElementAt(i);
                if (change.added == true)
                {
                    ret.Add("<ins>");
                }
                else if (change.removed == true)
                {
                    ret.Add("<del>");
                }

                ret.Add(HttpUtility.HtmlEncode(change.value));

                if (change.added == true)
                {
                    ret.Add("</ins>");
                }
                else if (change.removed == true)
                {
                    ret.Add("</del>");
                }
            }

            return String.Join("", ret);
        }
    }
}