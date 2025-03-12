using System;

namespace FastFuzzySearch
{
    public static class StringMatchingLogic
    {
        public static int HammingDistance(string target, string toCompare, int globalBest)
        {
            if (target.Length != toCompare.Length) return -1;
            int distance = 0;
            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] != toCompare[i])
                {
                    distance++;
                    if (distance > globalBest) return -1;
                }
            }
            return distance;
        }

        public static int LevenshteinDistance(string target, string toCompare, int globalBest)
        {
            int targetLength = target.Length, toCompareLength = toCompare.Length;
            int[,] distanceMatrix = new int[targetLength + 1, toCompareLength + 1];
            for (int i = 0; i < targetLength + 1; i++)
                distanceMatrix[i, 0] = i;
            for (int j = 0; j < toCompareLength + 1; j++)
                distanceMatrix[0, j] = j;
            for (int j = 1; j < toCompareLength + 1; j++)
            {
                int rowMin = int.MaxValue;
                for (int i = 1; i < targetLength + 1; i++)
                {
                    int cost = target[i - 1] != toCompare[j - 1] ? 1 : 0;
                    int sub = distanceMatrix[i - 1, j - 1] + cost;
                    int ins = distanceMatrix[i - 1, j] + 1;
                    int del = distanceMatrix[i, j - 1] + 1;
                    distanceMatrix[i, j] = Math.Min(sub, Math.Min(ins, del));
                    if (distanceMatrix[i, j] < rowMin) rowMin = distanceMatrix[i, j];
                }

                if (rowMin >= globalBest) return -1;
            }
            return distanceMatrix[targetLength, toCompareLength];
        }
    }
}
