using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFrequency
{
    public class WordFrequency
    {
        static void Main()
        {
            string wordsFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\Task_03\\words.txt"; 
            string textFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\Task_03\\text.txt";  
            string outputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\Task_03\\actualResults.txt"; 
            string expectedResultFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\Task_03\\expectedResult.txt";

            ProcessWordFrequency(wordsFilePath, textFilePath, outputFilePath, expectedResultFilePath);
        }
        
        public static void ProcessWordFrequency(string wordsFilePath, string textFilePath, string outputFilePath, string expectedResultFilePath)
        {
            
            if (!File.Exists(wordsFilePath) || !File.Exists(textFilePath))
            {
                Console.WriteLine("Один або обидва файли не знайдено.");
                return;
            }
            
            HashSet<string> wordsToFind = new HashSet<string>(File.ReadLines(wordsFilePath).Select(w => w.Trim().ToLower()));
            
            string text = File.ReadAllText(textFilePath).ToLower();

         
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in wordsToFind)
            {
                int count = CountOccurrences(text, word);
                if (count > 0)
                {
                    wordCount[word] = count;
                }
            }
            
            var sortedWordCount = wordCount.OrderByDescending(kvp => kvp.Value);
            
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var entry in sortedWordCount)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }

            Console.WriteLine($"Результати записано у файл: {outputFilePath}");
            
            CompareResults(outputFilePath, expectedResultFilePath);
        }
        
        public static int CountOccurrences(string text, string word)
        {
            int count = 0;
            int wordLength = word.Length;
            int index = 0;

            while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += wordLength;
            }

            return count;
        }
        
        public static void CompareResults(string actualResultFilePath, string expectedResultFilePath)
        {
            if (!File.Exists(expectedResultFilePath))
            {
                Console.WriteLine("Файл з очікуваними результатами не знайдено.");
                return;
            }

            var actualResults = File.ReadLines(actualResultFilePath);
            var expectedResults = File.ReadLines(expectedResultFilePath);
            
            bool isEqual = actualResults.SequenceEqual(expectedResults);

            if (isEqual)
            {
                Console.WriteLine("Результати співпадають з очікуваними.");
            }
            else
            {
                Console.WriteLine("Результати не співпадають з очікуваними.");
            }
        }
    }
}
