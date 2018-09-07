namespace DataTables.AspNetCore.Mvc.Binder
{
    /// <summary>
    /// Represents a datatable column
    /// </summary>
    public class DataTableColumn
    {
        /// <summary>
        /// Initialize a new instance of <see cref="DataTableColumn"/>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <param name="searchable"></param>
        /// <param name="orderable"></param>
        /// <param name="searchValue"></param>
        /// <param name="regex"></param>
        public DataTableColumn(string data, string name, bool searchable, bool orderable, string searchValue, bool regex)
        {
            this.Data = data;
            this.Name = name;
            this.Searchable = searchable;
            this.Orderable = orderable;
            this.SearchValue = searchValue;
            this.SearchRegEx = regex;
        }

        /// <summary>
        /// Column's data source, as defined by columns.data.
        /// </summary>
        public string Data { get; }

        /// <summary>
        /// Column's name, as defined by columns.name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Flag to indicate if this column is searchable (true) or not (false). This is controlled by columns.searchable.
        /// </summary>
        public bool Searchable { get; }

        /// <summary>
        /// Flag to indicate if this column is orderable (true) or not (false). This is controlled by columns.orderable.
        /// </summary>
        public bool Orderable { get; }

        /// <summary>
        /// Search value to apply to this specific column.
        /// </summary>
        public string SearchValue { get; }

        /// <summary>
        /// Flag to indicate if the search term for this column should be treated as regular expression (true) or not (false). 
        /// As with global search, normally server-side processing scripts will not perform regular expression searching for performance reasons on large data sets, but it is technically possible and at the discretion of your script.
        /// </summary>
        public bool SearchRegEx { get; }
    }
}
