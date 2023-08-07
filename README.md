[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=ThomasHambach_csharpdiff&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=ThomasHambach_csharpdiff) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ThomasHambach_csharpdiff&metric=coverage)](https://sonarcloud.io/summary/new_code?id=ThomasHambach_csharpdiff) [![NuGet](https://img.shields.io/nuget/v/CSharpDiff.svg)](https://www.nuget.org/packages/CSharpDiff) [![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE) [![GitHub contributors](https://img.shields.io/github/contributors/thomashambach/csharpdiff.svg)](https://github.com/thomashambach/csharpdiff/graphs/contributors) 

# CSharpDiff

C# Diff with Unified Diff Support, this codebase is a port from the popular JS library [jsdiff](https://github.com/kpdecker/jsdiff) by [kpdecker](https://github.com/kpdecker).

## Todo

- [ ] Clean-up code (Code smells and bugs according to Sonar)
- [ ] Patch
  - [x] Create
  - [ ] Apply
  - [ ] Merge
  - [ ] Parse
- [ ] Diff
  - [ ] Array
  - [x] Base `Diff()`
  - [x] Character `Diff()`
  - [ ] CSS
  - [ ] JSON
  - [x] Line `DiffLines()`
  - [x] Sentence `DiffSentence()`
  - [ ] Word (Partial, issues with Regex in `DiffWord.Tokenize`)
- [x] Convert `DiffConvert`
  - [x] XML `DiffConvert.ToXml`
  - [x] DMP (diff-match-patch) `DiffConvert.ToDmp`

## Usage Example

### Diff

#### Character

```c#
using CSharpDiff.Diff;

var diff = new Diff(new DiffOptions
{
    IgnoreCase = true
});
var result = diff.diff("New Value.", "New value.");
```

#### Line

```c#
using CSharpDiff.Diff;

var text1 = "Here im.\nRock you like old man.\nYeah";
var text2 = "Here im.\nRock you like hurricane.\nYeah";

var diff = new DiffLines();
var difference = diff.diff(text1, text2);
```

#### Sentence

```c#
using CSharpDiff.Diff;

var text1 = "Here im. Rock you like old man.";
var text2 = "Here im. Rock you like hurricane.";

var diff = new DiffSentence();
var difference = diff.diff(text1, text2);
```

### Patch

#### Create

```c#
using CSharpDiff.Patch;

var text1 = "...";
var text2 = "...";

var ps = new Patch();
string patch = ps.create("filename1", "filename2", text1, text2, "header1", "header2", new PatchOptions());
```

#### Apply

The `Apply` method in the `PatchApply` class applies a patch to a given source string. Here is an example of how to use it:

```c#
using CSharpDiff.Patches;

var patchApply = new PatchApply();
var source = "Hello, World!";
var patch = "-Hello\n+Goodbye";
var result = patchApply.Apply(source, patch);
```

### Works Well With

* [Diff2HTML](https://diff2html.xyz/)

## Contributing

Idk, just make a pull request.