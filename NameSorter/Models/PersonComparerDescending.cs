namespace NameSorter.Models
{
    public class PersonComparerDescending : IComparer<PersonName>
    {
        public int Compare(PersonName? first, PersonName? second)
        {
            if (first is not null && second is not null)
            {
                int value = second.LastName.SequenceCompareTo(first.LastName);

                if (value == 0)
                {
                    value = second.GivenNames.SequenceCompareTo(first.GivenNames);
                }

                return value;
            }

            if (first is null && second is null)
            {
                return 0;
            }

            if (second is not null)
            {
                // Only the second instance is not null, so prefer that.
                return -1;
            }

            // Only the first instance is not null, so prefer that.
            return 1;
        }
    }
}
