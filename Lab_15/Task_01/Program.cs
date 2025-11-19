using System;
using System.IO;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\15. Even Lines_Skeleton\\Skeleton-Exercise\\EvenLines\\text.txt"; 

            
            ProcessLines(inputFilePath);
        }

        public static void ProcessLines(string inputFilePath)
        {
            
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл не знайдено.");
                return;
            }
            
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                int lineNumber = 0;
                
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineNumber % 2 == 0)
                    {
                        Console.WriteLine(ProcessLine(line));
                    }
                    lineNumber++;
                }
            }
        }
        
        static string ProcessLine(string line)
        {
            char[] replacements = { '-', ',', '.', '!', '?' };
            foreach (var ch in replacements)
            {
                line = line.Replace(ch, '@');
            }
            
            string[] words = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);
            return string.Join(" ", words);
        }
    }
}
