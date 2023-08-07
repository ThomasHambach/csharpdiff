using CSharpDiff.Patches;

namespace CSharpDiff.Tests
{

    public class PatchTests
    {
        private string oldFile =
      "value\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "remove value\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "remove value\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "context\n"
      + "value\n"
      + "context\n"
      + "context";
        private string newFile =
              "new value\n"
              + "new value 2\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "add value\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "context\n"
              + "new value\n"
              + "new value 2\n"
              + "context\n"
              + "context";

        [Fact]
        public void ShouldHandleLastLine()
        {
            var patch = new Patch();

            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -1,3 +1,4 @@\n"
                            + " line2\n"
                            + " line3\n"
                            + "+line4\n"
                            + " line5\n";
            var res = patch.create("test", "test", "line2\nline3\nline5\n", "line2\nline3\nline4\nline5\n", "header1", "header2");
            Assert.Equal(expected, res);

            expected = "Index: test\n"
                        + "===================================================================\n"
                        + "--- test\theader1\n"
                        + "+++ test\theader2\n"
                        + "@@ -1,3 +1,4 @@\n"
                        + " line2\n"
                        + " line3\n"
                        + " line4\n"
                        + "+line5\n";

            res = patch.create("test", "test", "line2\nline3\nline4\n", "line2\nline3\nline4\nline5\n", "header1", "header2");
            Assert.Equal(expected, res);

            expected = "Index: test\n"
                        + "===================================================================\n"
                        + "--- test\theader1\n"
                        + "+++ test\theader2\n"
                        + "@@ -1,4 +1,5 @@\n"
                        + " line1\n"
                        + " line2\n"
                        + " line3\n"
                        + "-line4\n"
                        + "+line44\n"
                        + "+line5\n";

            res = patch.create("test", "test", "line1\nline2\nline3\nline4\n", "line1\nline2\nline3\nline44\nline5\n", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldHandleNoNewLineNewEOF()
        {
            var patch = new Patch();
            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -1,4 +1,4 @@\n"
                            + " line1\n"
                            + " line2\n"
                            + " line3\n"
                            + "-line4\n"
                            + "+line4\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("test", "test", "line1\nline2\nline3\nline4\n", "line1\nline2\nline3\nline4", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldHandleNoNewLineOldEOF()
        {
            var patch = new Patch();
            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -1,4 +1,4 @@\n"
                            + " line1\n"
                            + " line2\n"
                            + " line3\n"
                            + "-line4\n"
                            + "\\ No newline at end of file\n"
                            + "+line4\n";
            var res = patch.create("test", "test", "line1\nline2\nline3\nline4", "line1\nline2\nline3\nline4\n", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldHandleNoNewLineContextMissing()
        {
            var patch = new Patch();
            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -1,4 +1,4 @@\n"
                            + "-line11\n"
                            + "+line1\n"
                            + " line2\n"
                            + " line3\n"
                            + " line4\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("test", "test", "line11\nline2\nline3\nline4", "line1\nline2\nline3\nline4", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldOutPutNoNewLineOnEmpty()
        {
            var patch = new Patch();
            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -0,0 +1,4 @@\n"
                            + "+line1\n"
                            + "+line2\n"
                            + "+line3\n"
                            + "+line4\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("test", "test", "", "line1\nline2\nline3\nline4", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldNotOutputNoNewLineWhenEofOutsideHunk()
        {
            var patch = new Patch();
            var expected = "Index: test\n"
                            + "===================================================================\n"
                            + "--- test\theader1\n"
                            + "+++ test\theader2\n"
                            + "@@ -1,5 +1,5 @@\n"
                            + "-line11\n"
                            + "+line1\n"
                            + " line2\n"
                            + " line3\n"
                            + " line4\n"
                            + " line4\n";
            var res = patch.create("test", "test", "line11\nline2\nline3\nline4\nline4\nline4\nline4", "line1\nline2\nline3\nline4\nline4\nline4\nline4", "header1", "header2");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldGeneratePatchDefaultContextSize()
        {
            var patch = new Patch();
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\tOld Header\n"
                            + "+++ testFileName\tNew Header\n"
                            + "@@ -1,5 +1,6 @@\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "@@ -7,9 +8,8 @@\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "-remove value\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "@@ -17,20 +17,21 @@\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "-remove value\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "+add value\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n"
                            + " context\n"
                            + " context\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("testFileName", "testFileName", oldFile, newFile, "Old Header", "New Header");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldGeneratePatchWithContextSize0()
        {
            var patch = new Patch(new Patches.Models.PatchOptions
            {
                Context = 0
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\tOld Header\n"
                            + "+++ testFileName\tNew Header\n"
                            + "@@ -1,1 +1,2 @@\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n"
                            + "@@ -11,1 +11,0 @@\n"
                            + "-remove value\n"
                            + "@@ -21,1 +20,0 @@\n"
                            + "-remove value\n"
                            + "@@ -29,0 +29,1 @@\n"
                            + "+add value\n"
                            + "@@ -34,1 +34,2 @@\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n";
            var res = patch.create("testFileName", "testFileName", oldFile, newFile, "Old Header", "New Header");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldGeneratePatchWithContextSize2()
        {
            var patch = new Patch(new Patches.Models.PatchOptions
            {
                Context = 2
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\tOld Header\n"
                            + "+++ testFileName\tNew Header\n"
                            + "@@ -1,3 +1,4 @@\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n"
                            + " context\n"
                            + " context\n"
                            + "@@ -9,5 +10,4 @@\n"
                            + " context\n"
                            + " context\n"
                            + "-remove value\n"
                            + " context\n"
                            + " context\n"
                            + "@@ -19,5 +19,4 @@\n"
                            + " context\n"
                            + " context\n"
                            + "-remove value\n"
                            + " context\n"
                            + " context\n"
                            + "@@ -28,9 +27,11 @@\n"
                            + " context\n"
                            + " context\n"
                            + "+add value\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + " context\n"
                            + "-value\n"
                            + "+new value\n"
                            + "+new value 2\n"
                            + " context\n"
                            + " context\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("testFileName", "testFileName", oldFile, newFile, "Old Header", "New Header");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldOutputHeadersOnlyForIdentical()
        {
            var patch = new Patch();
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\tOld Header\n"
                            + "+++ testFileName\tNew Header\n";
            var res = patch.create("testFileName", "testFileName", oldFile, oldFile, "Old Header", "New Header");
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldOmitHeadersIfEmpty()
        {
            var patch = new Patch();
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n";
            var res = patch.create("testFileName", "testFileName", oldFile, oldFile, null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldHandleEmpty()
        {
            var patch = new Patch();
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n";
            var res = patch.create("testFileName", "testFileName", "", "", null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldOmitIndexDifferentFilenames()
        {
            var patch = new Patch();
            var expected = "===================================================================\n"
                            + "--- foo\n"
                            + "+++ bar\n";
            var res = patch.create("foo", "bar", "", "", null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldNotIgnoreWhiteSpace()
        {
            var patch = new Patch(new Patches.Models.PatchOptions { }, new Diffs.Models.DiffOptions
            {
                IgnoreWhiteSpace = false
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n"
                            + "@@ -1,2 +1,2 @@\n"
                            + "-line   \n"
                            + "- line\n"
                            + "\\ No newline at end of file\n"
                            + "+line\n"
                            + "+line\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("testFileName", "testFileName", "line   \n line", "line\nline", null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldIgnoreWhiteSpace()
        {
            var patch = new Patch(new Patches.Models.PatchOptions { }, new Diffs.Models.DiffOptions
            {
                IgnoreWhiteSpace = true
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n";
            var res = patch.create("testFileName", "testFileName", "line   \n line", "line\nline", null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldNotConsiderNewLineToken()
        {
            var patch = new Patch(new Patches.Models.PatchOptions { }, new Diffs.Models.DiffOptions
            {
                NewlineIsToken = false
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n"
                            + "@@ -1,2 +1,2 @@\n"

                            // Diff is shown as entire row, eventhough text is unchanged
                            + "-line\n"
                            + "+line\r\n"

                            + " line\n"
                            + "\\ No newline at end of file\n";
            var res = patch.create("testFileName", "testFileName", "line\nline", "line\r\nline", null, null);
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ShouldConsiderNewLineToken()
        {
            var patch = new Patch(new Patches.Models.PatchOptions { }, new Diffs.Models.DiffOptions
            {
                NewlineIsToken = true
            });
            var expected = "Index: testFileName\n"
                            + "===================================================================\n"
                            + "--- testFileName\n"
                            + "+++ testFileName\n"
                            + "@@ -1,3 +1,3 @@\n"
                            + " line\n"

                          // Newline change is shown as a single diff
                          + "-\n"
                          + "+\r\n"

                          + " line\n"
                          + "\\ No newline at end of file\n";
            var res = patch.create("testFileName", "testFileName", "line\nline", "line\r\nline", null, null);
            Assert.Equal(expected, res);
        }

    [Fact]
    public void ShouldApplyPatchCorrectly()
    {
        var patchApply = new PatchApply();
        var source = "Hello, World!";
        var patch = "-Hello\n+Goodbye";
        var expected = "Goodbye, World!";
        var result = patchApply.Apply(source, patch);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldHandleEmptyPatch()
    {
        var patchApply = new PatchApply();
        var source = "Hello, World!";
        var patch = "";
        var expected = "Hello, World!";
        var result = patchApply.Apply(source, patch);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldHandleEmptySourceString()
    {
        var patchApply = new PatchApply();
        var source = "";
        var patch = "+Hello, World!";
        var expected = "Hello, World!";
        var result = patchApply.Apply(source, patch);
        Assert.Equal(expected, result);
    }
}