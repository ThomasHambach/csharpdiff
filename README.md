# CSharpDiff

C# Diff with Unified Diff Support, this codebase is a port from the popular JS library [jsdiff](https://github.com/kpdecker/jsdiff) by [kpdecker](https://github.com/kpdecker).

## Warning

*The only functionality implemented at this time is the unified diff. Everything is guaranteed to be a bit buggy.*

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

### Works Well With

* [Diff2HTML](https://diff2html.xyz/)

## Todo

- [ ] Clean-up code
- [ ] Unit tests
- [ ] Support word based diff
- [ ] Port patch apply

## Contributing

Idk, just make a pull request.
