using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Select has the ability to select rows, columns or cells in a DataTable. 
    /// As well as being able to select each table element type you can also 
    /// combine the selection to have multiple different item types selected at 
    /// the same time.
    /// </summary>
    public enum SelectItemsType
    {
        /// <summary>
        /// Select rows
        /// </summary>
        Row,
        /// <summary>
        /// Select columns
        /// </summary>
        Column,
        /// <summary>
        /// Select cells
        /// </summary>
        Cell
    }
}
