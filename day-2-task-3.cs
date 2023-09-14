using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;

public class PalindromeChecker
{
    public static bool IsPalindrome(string inputString)
    {
        int length = inputString.Length;

        // Handle empty string
        if (length == 0) return false;

        // Ignore non-alphanumeric characters
        Regex nonAlphanumeric = new Regex("[^a-z0-9]");
        inputString = inputString.ToLower();
        inputString = nonAlphanumeric.Replace(inputString, "");

        // Two-pointer approach O(n)
        int left = 0;
        int right = length - 1;
        while (left < right)
        {
            // Check for anomaly
            if (inputString[left] != inputString[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }

    public static void Main()
    {
        Console.WriteLine(IsPalindrome("racecar"));
        Console.WriteLine(IsPalindrome("hello"));
    }
}

// Test

using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibraries;

namespace PalindromeCheckerTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestIsPalindrome()
        {
            // Tests that we expect to return true.
            string[] testStrings = { "hello", "level", "noon" };
            bool[] expectedResults = { false, true, true };
            int testCases = 3;

            for (int i = 0; i < testCases; i++)
            {
                bool result = PalindromeChecker.IsPalindrome(testStrings[i]);
                Assert.IsTrue(result == expectedResults[i],
                    string.Format("Expected '{0}' to be a palindrome: {1}, but got: {2}",
                        testStrings[i], expectedResults[i], result));
            }
        }
    }
}
