using Microsoft.Extensions.Logging;
using NameSorter.FileHandling;
using NameSorter.Sorting;

const string OutputFileName = "sorted-names-list.txt";

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
ILogger logger = factory.CreateLogger<Program>();

try
{
    string filePath = args.Length > 0 ? args[0] : null;

    if (filePath is null)
    {
        filePath = "SampleInput\\sample-unsorted-names-list-1000.txt";
    }

    Console.WriteLine($"Reading from: {filePath}");

    IFileReader fileReader = new FileReader();
    string[] lines = fileReader.ReadAllLines(filePath).ToArray();

    IPersonNamesSorter<string> sorter = new PersonNamesSpanBasedSorter();
    IEnumerable<string> sortedNames = sorter.Sort(lines);

    IFileWriter fileWriter = new FileWriter();
    fileWriter.WriteAllLines(OutputFileName, sortedNames);

    Console.WriteLine($"Output written to: {OutputFileName}");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred");
}

// Console.ReadKey();