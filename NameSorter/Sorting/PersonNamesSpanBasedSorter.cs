using NameSorter.Models;

namespace NameSorter.Sorting
{
    public class PersonNamesSpanBasedSorter : IPersonNamesSorter<string>
    {
        public IEnumerable<string> Sort(IEnumerable<string> names)
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

            personNames.Sort();

            return personNames.Select(pn => pn.FullName);
        }
    }
}
