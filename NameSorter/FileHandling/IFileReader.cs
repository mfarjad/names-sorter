namespace NameSorter.FileHandling
{
    public interface IFileReader
    {
        IEnumerable<string> ReadAllLines(string filePath);
    }
}
