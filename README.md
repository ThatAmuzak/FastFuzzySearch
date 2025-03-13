# Fast Fuzzy Search in Unity

A Unity Package to implement fuzzy string search from a list.

This is a very bare-bones package right now, that implements [Levenshtein Distance](https://en.wikipedia.org/wiki/Levenshtein_distance) and [Hamming Distance](https://en.wikipedia.org/wiki/Hamming_distance) as string search algorithms

## TODO

- [ ] Add more string matching approaches
  - [ ] [Damerau–Levenshtein Distance](https://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance)
  - [ ] [Jaro-Winkler Distance](https://en.wikipedia.org/wiki/Jaro%E2%80%93Winkler_distance)
  - [ ] [Longest Common Subsequence](https://en.wikipedia.org/wiki/Longest_common_subsequence)
  - [ ] modified [Smith-Waterman](https://en.wikipedia.org/wiki/Smith%E2%80%93Waterman_algorithm) from [fzf](https://github.com/junegunn/fzf/blob/master/src/algo/algo.go)
  - [ ] [Sublime Text's Fuzzy Matching Approach](https://github.com/forrestthewoods/lib_fts/blob/master/docs/fuzzy_match.md)
- [ ] Implement different target heuristics, simialar to [TheFuzz](https://github.com/seatgeek/thefuzz)
- [ ] Move the entire codebase to Burst for more optimization on larger search lists
