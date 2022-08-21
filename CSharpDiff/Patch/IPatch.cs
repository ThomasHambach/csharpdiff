using CSharpDiff.Patch.Models;

namespace CSharpDiff.Patch
{
    public interface IPatch
    {
        string[] contextLines(string[] lines);

        /// <summary>
        /// Create a text version of a unified diff patch.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="newStr"></param>
        /// <param name="oldStr"></param>
        /// <param name="oldHeader"></param>
        /// <param name="newHeader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        string create(string oldFileName, string newFileName, string newStr, string oldStr, string oldHeader, string newHeader, PatchOptions options);

        /// <summary>
        /// Create object of PatchResult that can be consumed by `formatPatch` to create a unified diff.
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="newStr"></param>
        /// <param name="oldStr"></param>
        /// <param name="oldHeader"></param>
        /// <param name="newHeader"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        PatchResult createPatchResult(string oldFileName, string newFileName, string newStr, string oldStr, string oldHeader, string newHeader, PatchOptions options);

        /// <summary>
        /// Format to unified diff patch using PatchResult
        /// </summary>
        /// <param name="diff"></param>
        /// <returns></returns>
        string formatPatch(PatchResult diff);
    }
}