namespace Redky.AspnetCore.Mvc
{
    class GridOptions<T> where T : class
    {
        /// <summary>
        /// Enable or disable table pagination
        /// </summary>
        public bool Paging { get; set; } = true;

        /// <summary>
        /// Feature control ordering (sorting) abilities in DataTables.
        /// </summary>
        public bool Ordering { get; set; } = true;

        /// <summary>
        /// Feature control table information display field.
        /// </summary>
        public bool Info { get; set; } = true;

        /// <summary>
        /// Multiple column ordering ability control.
        /// </summary>
        public bool OrderMulti { get; set; } = true;

        /// <summary>
        /// Gets the grid name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Define the table control elements to appear on the page and in what order.
        /// </summary>
        public string Dom { get; internal set; }

        /// <summary>
        /// State saving - restore table state on page reload.
        /// </summary>
        public bool StateSave { get; set; }

        /// <summary>
        /// Pagination button display options.
        /// </summary>
        public PagingType PagingType { get; set; } = PagingType.Simple_numbers;

        /// <summary>
        /// Data property name that DataTables will use to set tr element DOM IDs.
        /// </summary>
        public string RowId { get; internal set; }

        /// <summary>
        /// Allow the table to reduce in height when a limited number of rows are shown.
        /// </summary>
        public bool ScrollCollapse { get; internal set; }

        /// <summary>
        /// Vertical scrolling.
        /// </summary>
        public string ScrollY { get; set; }

        /// <summary>
        /// Horizontal scrolling
        /// </summary>
        public bool ScrollX { get; set; }

        /// <summary>
        /// Feature control the processing indicator.
        /// </summary>
        public bool Processing { get; set; }

        /// <summary>
        /// Feature control DataTables' server-side processing mode.
        /// </summary>
        public bool ServerSide { get; set; }
    }
}