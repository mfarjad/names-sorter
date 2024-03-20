namespace NameSorter.FileHandling
{
    public class FileWriter : IFileWriter
    {
        public void WriteAllLines(string filePath, IEnumerable<string> lines)
        {
            ArgumentNullException.ThrowIfNull(filePath);
            ArgumentNullException.ThrowIfNull(lines);

            File.WriteAllLines(filePath, lines);
        }
    }
}
