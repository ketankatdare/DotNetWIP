// See https://aka.ms/new-console-template for more information
using DirAndFileOps;
using System.Diagnostics;

//await RandomFileGenerator.Main();
//return;

var stopwatch = Stopwatch.StartNew();

string folderA = @"C:\Users\ketan\Projects\Temp\folderA";
string folderB = @"C:\Users\ketan\Projects\Temp\folderB";
string outputFile = @"C:\Users\ketan\Projects\Temp\matches.csv";
int countA = 0, countB = 0;

try
{
	// Build dict for folder B
    var fileNameToFullPathsB = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
    Console.WriteLine($"Loading files from {folderB}...");
    foreach (var filePath in Directory.EnumerateFiles(folderB))
    {
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

        if (!fileNameToFullPathsB.TryGetValue(fileNameWithoutExt, out var list))
        {
            list = new List<string>();
            fileNameToFullPathsB[fileNameWithoutExt] = list;
        }

        list.Add(filePath);
        countB++;
    }
    Console.WriteLine($"Loaded {countB} filenames from {folderB}");

    // Process folder A
    Console.WriteLine($"Comparing files from {folderA}...");
    var matches = new List<(string fileA, string fileB)>();
    foreach (var filePathA in Directory.EnumerateFiles(folderA))
    {
        string fileNameWithoutExtA = Path.GetFileNameWithoutExtension(filePathA);
        if (fileNameToFullPathsB.TryGetValue(fileNameWithoutExtA, out var matchingFilePathsB)) 
        {
            foreach (var matchingPathB in matchingFilePathsB)
            {
                matches.Add((filePathA, matchingPathB));
                //Console.WriteLine($"Match found: {filePathA} <--> {matchingPathB}");
            }
        }
        countA++;
    }
    Console.WriteLine($"Compared {countA} filenames from {folderA}");

    // Write output
    Console.WriteLine("Writing output file...");
    using (var writer = new StreamWriter(outputFile))
    {
        writer.WriteLine($"{folderA},{folderB}");

        foreach (var match in matches)
        {
            writer.WriteLine($"\"{match.fileA}\",\"{match.fileB}\"");
        }
    }

    Console.WriteLine($"Matching filenames written to {outputFile}");
}
catch (IOException ex)
{
    Console.WriteLine($"IO Error: {ex.Message}");
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Access Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected Error: {ex.Message}");
}

stopwatch.Stop();  // Stop timing
Console.WriteLine($"Total time taken: {stopwatch.Elapsed}");