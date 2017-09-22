using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    class GridColumnOptions
    {
        //columns.cellType
        //columns.className
        //columns.contentPadding
        //columns.createdCell
        //columns.data
        //columns.defaultContent
        //columns.name
        //columns.orderable
        //columns.orderData
        //columns.orderDataType
        //columns.render
        //columns.searchable
        //columns.title
        //columns.type
        //columns.visible
        //columns.width

        /// <summary>
        /// Cell type to be created for a column.
        /// </summary>
        public CellType CellType { get; set; } = CellType.td;

        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Add padding to the text content used when calculating the optimal with for a table.
        /// </summary>
        public string ContentPadding { get; set; }

        /// <summary>
        /// Cell created callback to allow DOM manipulation.
        /// </summary>
        ///public string CreatedCellCallback { get; set; }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <remarks>See https://datatables.net/reference/option/columns.data</remarks>
        public object Data { get; set; }

        /// <summary>
        /// Set default, static, content for a column.
        /// </summary>
        public string DefaultContent { get; set; }

        /// <summary>
        /// Set a descriptive name for a column.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Enable or disable ordering on this column. 
        /// </summary>
        public bool Orderable { get; set; } = true;

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        public int[] OrderData { get; set; }

        /// <summary>
        /// Live DOM sorting type assignment.
        /// </summary>
        public string OrderDataType { get; set; }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        public RenderOptions Render { get; set; }
        
        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        public bool Searchable { get; set; } = true;

        /// <summary>
        /// Set the column title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Set the column type - used for filtering and sorting string processing.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Column width assignment.
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// Action call when button clicked inside column
        /// </summary>
        public string Click { get; set; }
    }
}
