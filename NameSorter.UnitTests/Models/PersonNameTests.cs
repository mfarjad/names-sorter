using FluentAssertions;
using NameSorter.Models;

namespace NameSorter.UnitTests.Models
{
    public class PersonNameTests
    {
        [Fact]
        public void NullArgument_ShouldThrowArgumentNullException()
        {
            // Arrange
            string fullName = null;
            Action action = () => new PersonName(fullName);

            // Act and Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void InvalidName_ShouldThrowArgumentException()
        {
            // Arrange
            string fullName = "John";
            Action action = () => new PersonName(fullName);

            // Act and Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CompareTo_NullObject_Returns1()
        {
            // Arrange
            PersonName name = new("Janet Parsons");

            // Act
            int result = name.CompareTo(null);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public void CompareTo_SameLastNameAndGivenNames_Returns0()
        {
            // Arrange
            PersonName name1 = new("Janet Parsons");
            PersonName name2 = new("Janet Parsons");

            // Act
            int result = name1.CompareTo(name2);

            // Assert
            result.Should().Be(0);
        }

        [Theory]
        [InlineData("Janet Parsons", "Janet Smith")]
        [InlineData("John Doe", "Smith Doe")]
        public void CompareTo_ReturnsNegativeValue(string fullName1, string fullName2)
        {
            // Arrange
            PersonName name1 = new(fullName1);
            PersonName name2 = new(fullName2);

            // Act
            int result = name1.CompareTo(name2);

            // Assert
            result.Should().BeNegative();
        }

        [Theory]
        [InlineData("Vaughn Lewis", "Adonis Julius Archer")]
        [InlineData("Smith Doe", "John Doe")]
        public void CompareTo_ReturnsPositiveValue(string fullName1, string fullName2)
        {
            // Arrange
            PersonName name1 = new(fullName1);
            PersonName name2 = new(fullName2);

            // Act
            int result = name1.CompareTo(name2);

            // Assert
            result.Should().BePositive();
        }
    }
}
