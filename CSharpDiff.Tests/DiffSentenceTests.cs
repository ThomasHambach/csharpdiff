using CSharpDiff.Converters;
using CSharpDiff.Diffs;

namespace CSharpDiff.Tests
{

    public class DiffSentenceTests
    {
        [Fact]
        public void ShouldDiffSentences()
        {
            var diff = new DiffSentence();
            var diffResult = diff.diff("New Value.", "New ValueMoreData.");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("<del>New Value.</del><ins>New ValueMoreData.</ins>", converted);
        }

        [Fact]
        public void ShouldDiffLastSentence()
        {
            var diff = new DiffSentence();
            var diffResult = diff.diff("Here im. Rock you like old man.", "Here im. Rock you like hurricane.");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("Here im. <del>Rock you like old man.</del><ins>Rock you like hurricane.</ins>", converted);
        }
    }
}