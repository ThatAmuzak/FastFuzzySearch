using System;

namespace FastFuzzySearch
{
    public static class StringMatchingLogic
    {
        public static int HammingDistance(string target, string toCompare, int globalBest = -1)
        {
            if (target.Length != toCompare.Length) return -1;
            int distance = 0;
            for (int i = 0; i < target.Length; i++)
                if (target[i] != toCompare[i]) distance++;
            return distance;
        }

    }
}
