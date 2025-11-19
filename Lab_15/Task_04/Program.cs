using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\15. Even Lines_Skeleton\\Skeleton-Exercise\\CopyBinaryFile\\copyMe.png";  
            string outputFilePath = "D:\\RiderProjects\\OOP_Labs\\Lab_15\\15. Even Lines_Skeleton\\Skeleton-Exercise\\CopyBinaryFile\\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }
        
        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Вхідний файл не знайдено.");
                return;
            }
            
            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    
                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputFileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            Console.WriteLine("Копіювання завершено.");
        }
    }
}