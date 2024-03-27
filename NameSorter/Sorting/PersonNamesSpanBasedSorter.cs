using NameSorter.Models;

namespace NameSorter.Sorting
{
    public class PersonNamesSpanBasedSorter : IPersonNamesSorter<string>
    {
        private readonly PersonComparerDescending descendingComparer = new(); 

        public IEnumerable<string> Sort(IEnumerable<string> names)
        {
            return Sort(names, true);
        }

        public IEnumerable<string> Sort(IEnumerable<string> names, bool isAscending = true)
        {
            ArgumentNullException.ThrowIfNull(names);

            if (!names.Any())
            {
                return Enumerable.Empty<string>();
            }

            List<PersonName> personNames = new List<PersonName>();

            foreach (string name in names)
            {
                personNames.Add(new PersonName(name));
            }

            if (isAscending)
            {
                personNames.Sort();
            }
            else
            {
                personNames.Sort(descendingComparer);
            }

            return personNames.Select(pn => pn.FullName);
        }
    }
}
