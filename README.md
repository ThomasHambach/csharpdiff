[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ThomasHambach_csharpdiff&metric=coverage)](https://sonarcloud.io/summary/new_code?id=ThomasHambach_csharpdiff) [![NuGet](https://img.shields.io/nuget/v/CSharpDiff.svg)](https://www.nuget.org/packages/CSharpDiff) [![MIT licensed](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE) [![GitHub contributors](https://img.shields.io/github/contributors/thomashambach/csharpdiff.svg)](https://github.com/thomashambach/csharpdiff/graphs/contributors)

# CSharpDiff

C# Diff with Unified Diff Support, this codebase is a port from the popular JS library [jsdiff](https://github.com/kpdecker/jsdiff) by [kpdecker](https://github.com/kpdecker).

## Warning

*The only functionality implemented at this time is the unified diff. Everything is guaranteed to be a bit buggy.*

## Usage Example

### Diff

#### Character

```c#
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
string patch = ps.create("filename1", "filename2", text1, text2, "header1", "header2", new PatchServiceOptions());
```

### Works Well With

* [Diff2HTML](https://diff2html.xyz/)

## Todo

- [ ] Clean-up code (Code smells and bugs according to Sonar)
- [ ] Patch
  - [x] Create
  - [ ] Apply
  - [ ] Merge
  - [ ] Parse
- [ ] Diff
  - [ ] Array (difficult, JS allows type mixing)
  - [x] Base
  - [x] Character
  - [ ] CSS
  - [ ] JSON
  - [x] Line
  - [x] Sentence
  - [ ] Word
- [ ] Convert
  - [x] XML
  - [ ] DMP

## Contributing

Idk, just make a pull request.
