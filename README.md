# CSharpDiff

C# Diff with Unified Diff Support, this codebase is a port from the popular JS library JSDiff.

The only functionality implied at this time is the unified diff. Everything is guaranteed to be a bit buggy.

## Usage Example

```c#
using CSharpDiff;

var text1 = "";
var text2 = "";

var ps = new Patch();
var ds = new Diff();
var patch = ps.CreateStructuredPatch("filename1", "filename2", text1, text2, "", "", new PatchServiceOptions());
var patch = ps.formatPatch(patch);
```

## Todo

- [] Clean-up code
- [] Unit tests
- [] Support word based diff
- [] Port patch apply

