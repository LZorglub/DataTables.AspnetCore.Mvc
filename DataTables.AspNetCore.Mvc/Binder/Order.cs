namespace DataTables.AspNetCore.Mvc.Binder
{
    /// <summary>
    /// Represents order in <see cref="DataTablesRequest"/>
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Initialize a new instance of <see cref="Order"/>
        /// </summary>
        /// <param name="column"></param>
        /// <param name="dir"></param>
        public Order(int column, string dir)
        {
            this.Column = column;
            this.Dir = dir;
        }

        /// <summary>
        /// Column to which ordering should be applied. This is an index reference to the columns array of information that is also submitted to the server.
        /// order[i][column]
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Ordering direction for this column. It will be asc or desc to indicate ascending ordering or descending ordering, respectively.
        /// order[i][dir]
        /// </summary>
        public string Dir { get; }
    }
}