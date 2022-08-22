using CSharpDiff.Converters;
using CSharpDiff.Diffs.Models;

namespace CSharpDiff.Tests
{
    public class DiffConvertXmlTests
    {
        [Fact]
        public void ConvertToXml_Success()
        {

            var changes = new List<DiffResult> {
            new DiffResult {
                added = false,
                removed = true,
                value = "test"
            },
            new DiffResult {
                added = true,
                removed = false,
                value = "test"
            },
        };

            var converted = DiffConvertXml.Convert(changes);
            Assert.Equal("<del>test</del><ins>test</ins>", converted);

        }
    }
}
