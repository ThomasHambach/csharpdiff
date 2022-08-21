using CSharpDiff.Convert;
using CSharpDiff.Diff;

namespace CSharpDiff.Tests
{

    public class DiffTests
    {
        [Fact]
        public void ShouldDiffLines()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\nold value\nline", "line\nnew value\nline");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("line\n<del>old value\n</del><ins>new value\n</ins>line", converted);
        }

        [Fact]
        public void ShouldDiffTheSameLines()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\nvalue\nline", "line\nvalue\nline");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("line\nvalue\nline", converted);
        }

        [Fact]
        public void ShouldHandleTrailingSpaces()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\nvalue \nline", "line\nvalue\nline");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("line\n<del>value \n</del><ins>value\n</ins>line", converted);
        }

        [Fact]
        public void ShouldHandleWindowsLineEndings()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\r\nold value\r\nline", "line\r\nnew value\r\nline");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("line\r\n<del>old value\r\n</del><ins>new value\r\n</ins>line", converted);
        }

        [Fact]
        public void ShouldHandleEmptyLines()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\n\nold value \n\nline", "line\n\nnew value\n\nline");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("line\n\n<del>old value \n</del><ins>new value\n</ins>\nline", converted);
        }

        [Fact]
        public void ShouldHandleEmptyInput()
        {
            var diff = new DiffLines();
            var diffResult = diff.diff("line\n\nold value \n\nline", "");
            var converted = DiffConvertXml.Convert(diffResult);
            Assert.Equal("<del>line\n\nold value \n\nline</del>", converted);
        }

        // @todo Support maxEditLength.
        // describe('given options.maxEditLength', function() {
        //     it('terminates early', function() {
        //         const diffResult = diffLines(
        //           'line\nold value\nline',
        //           'line\nnew value\nline', { maxEditLength: 1 });
        //         expect(diffResult).to.be.undefined;
        //     });
        //     it('terminates early - async', function(done) {
        //         function callback(diffResult)
        //         {
        //             expect(diffResult).to.be.undefined;
        //             done();
        //         }
        //         diffLines(
        //           'line\nold value\nline',
        //           'line\nnew value\nline', { callback, maxEditLength: 1 });
        //     });
        // });
    }
}