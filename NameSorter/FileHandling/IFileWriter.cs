namespace NameSorter.FileHandling
{
    public interface IFileWriter
    {
        void WriteAllLines(string path, IEnumerable<string> lines);
    }
}
