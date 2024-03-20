using FluentAssertions;
using NameSorter.FileHandling;

namespace NameSorter.UnitTests.FileHandling
{
    public class FileReaderTests
    {
        [Fact]
        public void ReadAllLines_ThrowsArgumentNullException_WhenFilePathIsNull()
        {
            // Arrange
            string filePath = null;
            FileReader fileReader = new();
            Action action = () => fileReader.ReadAllLines(filePath);

            // Act and Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ReadAllLines_ReturnsCorrectLines_WhenFilePathIsValid()
        {
            // Arrange
            string filePath = Constants.UnsortedNamesFilePath;
            string[] expectedLines = File.ReadAllLines(filePath);
            FileReader fileReader = new();

            // IFileReader mock = Substitute.For<IFileReader>();
            // mock.ReadAllLines(filePath).Returns(expectedLines);

            // Act
            // IEnumerable<string> actualLines = mock.ReadAllLines(filePath);
            IEnumerable<string> actualLines = fileReader.ReadAllLines(filePath);

            // Assert
            actualLines.Should().Equal(expectedLines);
        }
    }
}
