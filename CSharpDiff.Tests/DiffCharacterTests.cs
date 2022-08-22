using CSharpDiff.Converters;
using CSharpDiff.Diffs;
using CSharpDiff.Diffs.Models;

namespace CSharpDiff.Tests
{
    public class DiffCharacterTests
    {
        [Fact]
        public void ShouldDiffChars()
        {
            var diff = new Diff();
            var result = diff.diff("New Value.", "New ValueMoreData.");
            Assert.Equal("New Value<ins>MoreData</ins>.", DiffConvert.ToXml(result));
        }

        [Fact]
        public void ShouldConsiderCase()
        {
            var diff = new Diff(new DiffOptions
            {
                IgnoreCase = true
            });
            var result = diff.diff("New Value.", "New value.");
            Assert.Equal("New value.", DiffConvert.ToXml(result));
        }

        [Fact]
        public void ShouldConsiderCaseWithDifference()
        {
            var diff = new Diff(new DiffOptions
            {
                IgnoreCase = true
            });
            var result = diff.diff("New Values.", "New value.");
            Assert.Equal("New value<del>s</del>.", DiffConvert.ToXml(result));
        }
    }
}
