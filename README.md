# Fast Fuzzy Search in Unity

A Unity Package to implement fuzzy string search from a list.
Implements [Levenshtein Distance](https://en.wikipedia.org/wiki/Levenshtein_distance) and [Hamming Distance](https://en.wikipedia.org/wiki/Hamming_distance) as string search algorithms

## TODO

This is a very bare-bones package right now. Some of the items to check off before this package is worth a 1.0 release are as follows:

- [ ] Add more string matching approaches
  - [ ] [Damerau–Levenshtein Distance](https://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance)
  - [ ] [Jaro-Winkler Distance](https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance)
  - [ ] [Longest Common Subsequence](https://en.wikipedia.org/wiki/Longest_common_subsequence)
  - [ ] modified [Smith-Waterman](https://en.wikipedia.org/wiki/Smith%E2%80%93Waterman_algorithm) from [fzf](https://github.com/junegunn/fzf/blob/master/src/algo/algo.go)
  - [ ] [Sublime Text's Fuzzy Matching Approach](https://github.com/forrestthewoods/lib_fts/blob/master/docs/fuzzy_match.md)
- [ ] Implement different target heuristics, simialar to [TheFuzz](https://github.com/seatgeek/thefuzz)
- [ ] Move the entire codebase to Burst for optimized searches on larger lists
- [ ] Add Tests, samples, documentation
- [ ] Extensibility for custom scoring functions

## Installation

This package can be added to your project via [Git UPM](https://docs.unity3d.com/2022.3/Documentation/Manual/upm-git.html).
To add this package, copy:

```shell
https://github.com/ThatAmuzak/FastFuzzySearch.git
```

and add it as a git package in the Unity Package Manager.

## Usage

Simply use

```cs
FuzzySearch.GetBestOne(target, wordList);
```

to get the closest match. Alternatively, you can use

```cs
FuzzySearch.GetBestN(target, wordList, returnCount);
```

to get a list of the closest matches instead.

You can also select the matching algorithm, and if exact subsequences should get a boost to the score.
By default, the matching algorithm uses Levenshtein, and exact subsequences boost is false.

## Contributing

Please see the [CONTRIBUTING.md](CONTRIBUTING.md) file for details on contributing to this project.

## License

This project is licensed under the [Unlicensed License](https://unlicense.org/) - see the [LICENSE](LICENSE) file for details.
