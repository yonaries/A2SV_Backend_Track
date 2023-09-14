using System;
using System.Collections.Generic;

public class TextAnalyzer
{
    public static Dictionary<string, int> WordFrequencyCounter(string inputText)
    {
        Dictionary<string, int> wordFrequencyDictionary = new Dictionary<string, int>();
        string[] words = inputText.ToLower().Split(" ");
        foreach (string word in words)
        {
            if (wordFrequencyDictionary.ContainsKey(word))
            {
                wordFrequencyDictionary[word] += 1;
            }
            else
            {
                wordFrequencyDictionary[word] = 1;
            }
        }
        return wordFrequencyDictionary;
    }

    public static void Main()
    {
        foreach (KeyValuePair<string, int> kvp in WordFrequencyCounter("You for runner is running up north these days. This town is where I'd rather you be"))
        {
            Console.WriteLine("Word = {0}, Frequency = {1}", kvp.Key, kvp.Value);
        }
    }
}

// test

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace TextAnalyzerTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestWordFrequencyCount()
        {
            // Tests that we expect to return true.
            string[] words = { "you're", "the", "test", "that", "wants", "to" };
            int[] expectedValues = { 1, 1, 2, 1, 1, 1 };
            int testCases = 6;
            Dictionary<string, int> wordFrequencies = WordFrequencyCounter("You're the test that Wants to test");
            for (int i = 0; i < testCases; i++)
            {
                int result = wordFrequencies[words[i]];
                Assert.IsTrue(result == expectedValues[i],
                       string.Format("Expected word frequency for '{0}' to be {1}, but got {2}",
                                     words[i], expectedValues[i], result));
            }
        }
    }
}
