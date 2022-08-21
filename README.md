[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=ThomasHambach_csharpdiff&metric=coverage)](https://sonarcloud.io/summary/new_code?id=ThomasHambach_csharpdiff)

# CSharpDiff

C# Diff with Unified Diff Support, this codebase is a port from the popular JS library [jsdiff](https://github.com/kpdecker/jsdiff) by [kpdecker](https://github.com/kpdecker).

## Warning

*The only functionality implemented at this time is the unified diff. Everything is guaranteed to be a bit buggy.*

## Usage Example

### Diff

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
  - [ ] Character
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
