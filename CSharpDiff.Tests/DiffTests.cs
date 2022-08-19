using CSharpDiff.Convert;
using CSharpDiff.Diff;

public class DiffTests
{
    [Fact]
    public void ShouldDiffLines()
    {
        var diff = new DiffLines();
        var diffResult = diff.diff("line\nold value\nline", "line\nnew value\nline");
        var converted = DiffConvertXml.Convert(diffResult);
        Assert.Equal(converted, "line\n<ins>old value\n</ins><del>new value\n</del>line");
    }

    // it('should diff lines', function() {
    //     const diffResult = diffLines(
    //       'line\nold value\nline',
    //       'line\nnew value\nline');
    //     expect(convertChangesToXML(diffResult)).to.equal('line\n<del>old value\n</del><ins>new value\n</ins>line');
    // });
    // it('should the same lines in diff', function() {
    //     const diffResult = diffLines(
    //       'line\nvalue\nline',
    //       'line\nvalue\nline');
    //     expect(convertChangesToXML(diffResult)).to.equal('line\nvalue\nline');
    // });

    // it('should handle leading and trailing whitespace', function() {
    //     const diffResult = diffLines(
    //       'line\nvalue \nline',
    //       'line\nvalue\nline');
    //     expect(convertChangesToXML(diffResult)).to.equal('line\n<del>value \n</del><ins>value\n</ins>line');
    // });

    // it('should handle windows line endings', function() {
    //     const diffResult = diffLines(
    //       'line\r\nold value \r\nline',
    //       'line\r\nnew value\r\nline');
    //     expect(convertChangesToXML(diffResult)).to.equal('line\r\n<del>old value \r\n</del><ins>new value\r\n</ins>line');
    // });

    // it('should handle empty lines', function() {
    //     const diffResult = diffLines(
    //       'line\n\nold value \n\nline',
    //       'line\n\nnew value\n\nline');
    //     expect(convertChangesToXML(diffResult)).to.equal('line\n\n<del>old value \n</del><ins>new value\n</ins>\nline');
    // });

    // it('should handle empty input', function() {
    //     const diffResult = diffLines(
    //       'line\n\nold value \n\nline',
    //       '');
    //     expect(convertChangesToXML(diffResult)).to.equal('<del>line\n\nold value \n\nline</del>');
    // });

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