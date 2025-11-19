using System;
using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\15. Even Lines_Skeleton\\Skeleton-Exercise\\LineNumbers\\text.txt";  
            string outputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\15. Even Lines_Skeleton\\Skeleton-Exercise\\LineNumbers\\output.txt";
            
            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Вхідний файл не знайдено.");
                return;
            }
            
            int letterCount = 0;
            int punctuationCount = 0;
            
            string[] lines = File.ReadAllLines(inputFilePath);
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    writer.WriteLine($"{i + 1}: {line}");
                    
                    foreach (char c in line)
                    {
                        if (Char.IsLetter(c))
                        {
                            letterCount++;
                        }
                        else if (Char.IsPunctuation(c))
                        {
                            punctuationCount++;
                        }
                    }
                }
                
                writer.WriteLine();
                writer.WriteLine($"Загальна кількість літер: {letterCount}");
                writer.WriteLine($"Загальна кількість розділових знаків: {punctuationCount}");
            }

            Console.WriteLine("Обробка завершена. Результат записано у файл " + outputFilePath);
        }
    }
}
