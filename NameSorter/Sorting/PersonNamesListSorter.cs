namespace NameSorter.Sorting
{
    public class PersonNamesListSorter : IPersonNamesSorter<string>
    {
        public IEnumerable<string> Sort(IEnumerable<string> names)
        {
            ArgumentNullException.ThrowIfNull(names);

            if (!names.Any())
            {
                return Enumerable.Empty<string>();
            }

            List<Tuple<string, string>> result = new();

            foreach (string line in names)
            {
                int lastSpaceIndex = line.LastIndexOf(' ');

                result.Add(new Tuple<string, string>(line.Substring(lastSpaceIndex + 1), line.Substring(0, lastSpaceIndex)));
            }

            result.Sort();

            return result.Select(pn => $"{pn.Item2} {pn.Item1}");
        }
    }
}
