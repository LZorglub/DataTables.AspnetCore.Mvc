using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the options for select extension
    /// </summary>
    public class SelectOptions
    {

        /// <summary>
        /// Indicate if the selected items will be removed when clicking outside of the table.
        /// </summary>
        public bool Blurable { get; set; }

        /// <summary>
        /// Set the class name that will be applied to selected items
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Enable / disable the display for item selection information in the table summary. 
        /// </summary>
        public bool Info { get; set; } = true;

        /// <summary>
        /// Set which table items to select (rows, columns or cells). 
        /// </summary>
        public SelectItemsType Items { get; set; } = SelectItemsType.Row;

        /// <summary>
        /// Set the element selector used for mouse event capture to select items. 
        /// </summary>
        public string Selector { get; set; }

        /// <summary>
        /// Gets or sets the selection style for end user interaction with the table
        /// </summary>
        public SelectStyle Style { get; set; } = SelectStyle.Os;
    }
}
