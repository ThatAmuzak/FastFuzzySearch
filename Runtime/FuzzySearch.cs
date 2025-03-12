using System;
using System.Collections.Generic;

namespace FastFuzzySearch
{
    public static class FuzzySearch
    {
        public static string GetBestOne(string targetWord, List<string> wordList, MatchingTechnique technique = MatchingTechnique.LevenshteinDistance, bool enableBonusForExactMatch = false)
        {
            if (string.IsNullOrWhiteSpace(targetWord)) return "";
            return GetBestN(targetWord, wordList, 1, technique, enableBonusForExactMatch)[0];
        }

        public static List<string> GetBestN(string targetWord, List<string> wordList, int returnCount, MatchingTechnique technique = MatchingTechnique.LevenshteinDistance, bool enableBonusForExactMatch = false)
        {
            if (string.IsNullOrWhiteSpace(targetWord)) return null;
            targetWord = targetWord.ToLower();
            int globalBestOfList = Int32.MaxValue;
            List<KeyValuePair<float, string>> closestMatches = new List<KeyValuePair<float, string>>();
            foreach (string word in wordList)
            {
                int distance = -1;
                switch (technique)
                {
                    case MatchingTechnique.LevenshteinDistance:
                        distance = StringMatchingLogic.LevenshteinDistance(targetWord, word.ToLower(), globalBestOfList);
                        break;
                    case MatchingTechnique.HammingDistance:
                        distance = StringMatchingLogic.HammingDistance(targetWord, word.ToLower(), globalBestOfList);
                        break;
                }

                if (distance < 0) continue;
                float ratio = distance / (float) Math.Max(targetWord.Length, word.Length);
                if (enableBonusForExactMatch)
                {
                    if (word.ToLower().Contains(targetWord)) ratio -= 0.5f;
                    if (ratio < 0) ratio = 0;
                }

                if (closestMatches.Count <= 0)
                {
                    closestMatches.Add(new KeyValuePair<float, string>(ratio, word));
                }
                else
                {
                    for (int index = 0; index < closestMatches.Count; index++)
                    {
                        if (index >= returnCount) break;
                        if (closestMatches[index].Key > ratio)
                        {
                            closestMatches.Insert(index, new KeyValuePair<float, string>(ratio, word));
                            break;
                        }
                    }
                    if(closestMatches.Count > returnCount) closestMatches.RemoveAt(closestMatches.Count - 1);
                }
            }

            List<string> closestMatchesWords = new List<string>();
            foreach (KeyValuePair<float, string> matches in closestMatches)
            {
                closestMatchesWords.Add(matches.Value);
            }
            return closestMatchesWords;
        }
    }

    public enum MatchingTechnique
    {
        LevenshteinDistance = 0,
        HammingDistance = 1
    }
}
