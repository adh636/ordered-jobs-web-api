using System;
using System.Collections.Generic;

public class AllPermutations
{
    public List<string> GetPermutations(string testCase, char separator)
    {
        string[] testCaseArray = testCase.Split(separator);
        List<string> permutations = new List<string>();
        GenerateHeapPermutations(testCaseArray.Length, testCaseArray, permutations);
        return permutations;
    }

    private static void GenerateHeapPermutations(int length, string[] testCaseArray, List<string> permutations) {
        if (length == 1) {
            permutations.Add(String.Join("|", testCaseArray));
        }
        else {
            for (int i = 0; i < length; i++) {
                GenerateHeapPermutations(length - 1, testCaseArray, permutations);
                Swap(testCaseArray, length % 2 == 1 ? 0 : i, length - 1);
            }
        }
    }

    private static void Swap(string[] testCaseArray, int i, int j) {
        string temp = testCaseArray[i];
        testCaseArray[i] = testCaseArray[j];
        testCaseArray[j] = temp;
    }
}