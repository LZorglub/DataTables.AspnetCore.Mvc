namespace DataTables.AspNetCore.Mvc.Binder
{
    /// <summary>
    /// Represents the search options
    /// </summary>
    public class Search
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Search"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regex"></param>
        public Search(string value, bool regex)
        {
            this.Value = value;
            this.Regex = regex;
        }

        /// <summary>
        /// Global search value. To be applied to all columns which have searchable as true.
        /// search[value]
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// true if the global filter should be treated as a regular expression for advanced searching, false otherwise. Note that normally server-side processing scripts will not perform regular expression searching for performance reasons on large data sets, but it is technically possible and at the discretion of your script.
        /// search[regex]
        /// </summary>
        public bool Regex { get; }
    }
}