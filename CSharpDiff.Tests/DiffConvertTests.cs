using CSharpDiff.Converters;
using CSharpDiff.Diffs;
using CSharpDiff.Diffs.Models;

namespace CSharpDiff.Tests
{
    public class DiffConvertXmlTests
    {
        [Fact]
        public void ShouldConvertToXml()
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

            var converted = DiffConvert.ToXml(changes);
            Assert.Equal("<del>test</del><ins>test</ins>", converted);

        }

        [Fact]
        public void ShouldConvertToDmp()
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
            new DiffResult {
                added = false,
                removed = false,
                value = "test"
            },
        };

            var converted = DiffConvert.ToDmp(changes);
            Assert.Equal(-1, converted[0].Item1);
            Assert.Equal("test", converted[0].Item2);
            Assert.Equal(1, converted[1].Item1);
            Assert.Equal("test", converted[1].Item2);
            Assert.Equal(0, converted[2].Item1);
        }

    }
}
