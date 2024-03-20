using FluentAssertions;
using NameSorter.FileHandling;

namespace NameSorter.UnitTests.FileHandling
{
    public class FileWriterTests
    {
        [Fact]
        public void WriteAllLines_NullFilePath_ThrowsArgumentNullException()
        {
            // Arrange
            string filePath = null;
            IEnumerable<string> lines = ["John Doe", "Jane Smith"];
            FileWriter fileWriter = new();
            Action action = () => fileWriter.WriteAllLines(filePath, lines);

            // Act & Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WriteAllLines_NullLines_ThrowsArgumentNullException()
        {
            // Arrange
            string filePath = Constants.SortedNamesFilePath;
            IEnumerable<string> lines = null;
            FileWriter fileWriter = new();
            Action action = () => fileWriter.WriteAllLines(filePath, lines);

            // Act & Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WriteAllLines_ValidFilePathAndLines_CallsFileWriteAllLines()
        {
            // Arrange
            string filePath = Constants.SortedNamesFilePath;
            IEnumerable<string> expectedLines = File.ReadAllLines(Constants.UnsortedNamesFilePath);
            FileWriter fileWriter = new();

            // Act
            fileWriter.WriteAllLines(filePath, expectedLines);

            string[] actualLines = File.ReadAllLines(filePath);

            // Assert
            File.Exists(filePath).Should().BeTrue();
            actualLines.Should().Equal(expectedLines);
        }
    }
}
