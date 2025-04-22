// See https://aka.ms/new-console-template for more information
using DirAndFileOps;
using System.Diagnostics;

Console.WriteLine("Enter folder path containing *.cix files:");
string folderCix = Console.ReadLine();
Console.WriteLine("Enter folder path containing *.pdf files:");
string folderPdf = Console.ReadLine();
Console.WriteLine("Enter folder path for comparison output file:");
string outputFolder = Console.ReadLine(); 
string outputTxtFile = Path.Combine(outputFolder, "comparison.txt"); 
string outputCsvFile = Path.Combine(outputFolder, "comparison.csv");
int countCix = 0, countPdf = 0;

var stopwatch = Stopwatch.StartNew();

try
{
	// Build dict for folder B
    var fileNameToFullPathsPdf = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
    Console.WriteLine($"Loading files from {folderPdf}...");
    foreach (var filePath in Directory.EnumerateFiles(folderPdf,"*.pdf"))
    {
        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

        if (!fileNameToFullPathsPdf.TryGetValue(fileNameWithoutExt, out var list))
        {
            list = new List<string>();
            fileNameToFullPathsPdf[fileNameWithoutExt] = list;
        }

        list.Add(filePath);
        countPdf++;
    }
    Console.WriteLine($"Loaded {countPdf} filenames from {folderPdf}");

    // Process folder A
    Console.WriteLine($"Comparing files from {folderCix}...");
    var matches = new List<(string fileCix, string filePdf)>();
    var uniqueCixMatches = new HashSet<string>();
    foreach (var filePathCix in Directory.EnumerateFiles(folderCix,"*.cix"))
    {
        string fileNameWithoutExtCix = Path.GetFileNameWithoutExtension(filePathCix);

        var matchingFilesInPdf = fileNameToFullPathsPdf
        .Where(b => b.Key.StartsWith(fileNameWithoutExtCix, StringComparison.OrdinalIgnoreCase))
        .ToList();

        foreach (var matchingFile in matchingFilesInPdf)
        {
            foreach (var file in matchingFile.Value)
            {
                matches.Add((filePathCix, file));
                uniqueCixMatches.Add(fileNameWithoutExtCix);
            }
        }
        countCix++;
    }
    Console.WriteLine($"Compared {countCix} filenames from {folderCix}");

    // Write output
    Console.WriteLine("Writing output file to csv...");
    using (var writer = new StreamWriter(outputCsvFile))
    {
        writer.WriteLine($"CIXs,PDFs");

        foreach (var match in matches)
        {
            writer.WriteLine($"\"{match.fileCix}\",\"{match.filePdf}\"");
        }
    }
    Console.WriteLine($"Matching filenames written to {outputCsvFile}");

    Console.WriteLine("Writing output file to txt...");
    using (var writer = new StreamWriter(outputTxtFile))
    {
        foreach (var match in uniqueCixMatches)
        {
            writer.WriteLine(match);
        }
    }

    Console.WriteLine($"Matching filenames written to {outputTxtFile}");
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