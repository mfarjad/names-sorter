using FluentAssertions;
using NameSorter.Sorting;

namespace NameSorter.UnitTests.Sorting
{
    public class PersonNamesSorterTests
    {
        private IPersonNamesSorter<string> sorter;

        public PersonNamesSorterTests()
        {
            sorter = new PersonNamesSpanBasedSorter();
        }

        [Fact]
        public void Sort_ThrowsArgumentNullException_WhenNamesAreNull()
        {
            // Arrange
            string[] names = null;
            Action action = () => sorter.Sort(names);

            // Act and Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Sort_EmptyNames_ReturnsEmptyList()
        {
            // Arrange
            IEnumerable<string> names = Enumerable.Empty<string>();

            // Act
            IEnumerable<string> sortedNames = sorter.Sort(names);

            // Assert
            sortedNames.Should().BeEmpty();
        }

        [Theory]
        [InlineData(new string[] { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer" }, new string[] { "Adonis Julius Archer", "Vaughn Lewis", "Janet Parsons" })]
        [InlineData(new string[] { "Vaughn Parsons", "Janet Parsons", "Adonis Julius Archer" }, new string[] { "Adonis Julius Archer", "Janet Parsons", "Vaughn Parsons" })]
        public void Sort_Names_ReturnsSortedNames(string[] names, string[] expectedSortedNames)
        {
            // Arrange

            // Act
            var sortedNames = sorter.Sort(names);

            // Assert
            sortedNames.Should().Equal(expectedSortedNames);
        }
    }
}
