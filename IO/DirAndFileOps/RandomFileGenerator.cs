using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirAndFileOps
{
    public static class RandomFileGenerator
    {
        public static async Task Main()
        {
            string folderA = @"C:\Users\ketan\Projects\Temp\folderA"; // 8000 files
            string folderB = @"C:\Users\ketan\Projects\Temp\folderB"; // 800000 files

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Create test files");
            Console.WriteLine("2 - Delete test files");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await CreateTestFiles(folderA, 8000);
                    await CreateTestFiles(folderB, 800000);
                    break;
                case "2":
                    DeleteTestFiles(folderA);
                    DeleteTestFiles(folderB);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("Done.");
        }

        static async Task CreateTestFiles(string folderPath, int numberOfFiles)
        {
            Directory.CreateDirectory(folderPath);

            Console.WriteLine($"Creating {numberOfFiles} files in {folderPath}...");

            for (int i = 0; i < numberOfFiles; i++)
            {
                string fileName = $"testfile_{i:D5}.txt"; // example: testfile_00001.txt
                string filePath = Path.Combine(folderPath, fileName);

                // Create empty file
                using (var stream = new FileStream(filePath, FileMode.CreateNew))
                {
                    await stream.FlushAsync(); // optional, ensures file is really created
                }

                if (i % 1000 == 0)
                {
                    Console.WriteLine($"{i} files created...");
                }
            }

            Console.WriteLine($"Finished creating {numberOfFiles} files in {folderPath}.");
        }

        static void DeleteTestFiles(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Console.WriteLine($"Deleting all files in {folderPath}...");
                Directory.Delete(folderPath, true);
                Console.WriteLine($"Deleted folder {folderPath}.");
            }
            else
            {
                Console.WriteLine($"Folder {folderPath} does not exist. Nothing to delete.");
            }
        }
    }
}
