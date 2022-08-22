using CSharpDiff.Converters;
using CSharpDiff.Diffs;

namespace CSharpDiff.Tests
{

    public class DiffWordTests
    {
        [Fact]
        public void ShouldDiffWhitespace()
        {
            var diff = new DiffWord();
            var diffResult = diff.diff("New Value", "New  ValueMoreData");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("New  <del>Value</del><ins>ValueMoreData</ins>", converted);
        }

        [Fact]
        public void ShouldDiffMultipleWhitespace()
        {
            var diff = new DiffWord();
            var diffResult = diff.diff("New Value  ", "New  ValueMoreData ");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("New  <del>Value</del><ins>ValueMoreData</ins> ", converted);
        }


        [Fact]
        public void ShouldDiffOnWordBoundaries()
        {
            var diff = new DiffWord();
            var diffResult = diff.diff("New :Value:Test", "New  ValueMoreData ");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("New  <del>:Value:Test</del><ins>ValueMoreData </ins>", converted);

            // @todo Tests below still bug out due to the REGEX in DiffWord.Tokenize
            // diffResult = diff.diff("New Value:Test", "New  Value:MoreData ");
            // converted = DiffConvertXml.Convert(diffResult);
            // Assert.Equal("New  Value:<del>Test</del><ins>MoreData </ins>", converted);

            // diffResult = diff.diff("New Value-Test", "New  Value:MoreData ");
            // converted = DiffConvertXml.Convert(diffResult);
            // Assert.Equal("New  Value<del>-Test</del><ins>:MoreData </ins>", converted);

            // diffResult = diff.diff("New Value", "New  Value:MoreData ");
            // converted = DiffConvertXml.Convert(diffResult);
            // Assert.Equal("New  Value<del>-Test</del><ins>:MoreData </ins>", converted);
        }

        [Fact]
        public void ShouldHandleIdentity()
        {
            // var diff = new DiffWord();
            // var diffResult = diff.diff("New Value", "New Value");
            // var converted = DiffConvertXml.Convert(diffResult);
            // Assert.Equal("New  Value", converted);
        }

    }
}
