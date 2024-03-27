namespace NameSorter.Models
{
    public record PersonName : IComparable<PersonName>
    {
        private int lastSpaceIndex;
        public ReadOnlySpan<char> GivenNames => FullName.AsSpan(0, lastSpaceIndex);
        public ReadOnlySpan<char> LastName => FullName.AsSpan(lastSpaceIndex + 1);

        public string FullName { get; set; }

        public PersonName(string fullName)
        {
            ArgumentNullException.ThrowIfNull(fullName);

            fullName = fullName.Trim();

            lastSpaceIndex = fullName.LastIndexOf(' ');

            // todo: check for 3 given names max?

            if (lastSpaceIndex == -1)
            {
                throw new ArgumentException("Unexpected input format.", nameof(fullName));
            }

            FullName = fullName;
        }

        public int CompareTo(PersonName? obj)
        {
            if (obj is null) return 1;

            int value = LastName.SequenceCompareTo(obj.LastName);

            if (value == 0)
            {
                value = GivenNames.SequenceCompareTo(obj.GivenNames);
            }

            return value;
        }
    }
}
