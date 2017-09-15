using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redky.AspnetCore.Mvc
{
    public class GridColumn
    {
        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        public bool Searchable { get; set; } = true;

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        public string OrderData { get; set; }
    }
}
