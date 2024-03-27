namespace NameSorter.Sorting
{
    public interface IPersonNamesSorter<T> where T : IComparable<T>
    {
        /// <summary>
        /// Returns a sorted (by last name and then by given names) collection of full names.
        /// </summary>
        /// <param name="names">Collection of full names.</param>
        /// <returns></returns>
        public IEnumerable<T> Sort(IEnumerable<T> names);

        public IEnumerable<T> Sort(IEnumerable<T> names, bool isAscending = true);
    }
}
