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
        filePath = "SampleInput\\sample-unsorted-names-list.txt";
    }

    bool isAscending = false;

    if(args.Length > 1 && args[1]?.ToLower() == bool.TrueString.ToLower())
    {
        isAscending = true;
    }

    IFileReader fileReader = new FileReader();
    string[] lines = fileReader.ReadAllLines(filePath).ToArray();

    IPersonNamesSorter<string> sorter = new PersonNamesSpanBasedSorter(); // new PersonNamesListSorter();
    IEnumerable<string> sortedNames = sorter.Sort(lines, isAscending);

    // Write to console
    sortedNames.ToList().ForEach(Console.WriteLine);

    // Write to file
    IFileWriter fileWriter = new FileWriter();
    fileWriter.WriteAllLines(OutputFileName, sortedNames);

    // Write info
    Console.WriteLine($"\n\nInput read from: {filePath}");
    Console.WriteLine($"Output saved to: {OutputFileName}");
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred");
}

// Console.ReadKey();