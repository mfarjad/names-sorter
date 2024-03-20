namespace NameSorter.FileHandling
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> ReadAllLines(string filePath)
        {
            ArgumentNullException.ThrowIfNull(filePath);

            return File.ReadAllLines(filePath);
        }
    }
}
