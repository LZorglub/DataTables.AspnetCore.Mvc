using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Set the selection style for end user interaction with the table.
    /// </summary>
    public enum SelectStyle
    {
        /// <summary>
        /// Selection can only be performed via the API
        /// </summary>
        Api,
        /// <summary>
        /// Only a single item can be selected, any other selected items will be automatically deselected when a new item is selected
        /// </summary>
        Single,
        /// <summary>
        /// Multiple items can be selected. Selection is performed by simply clicking on the items to be selected
        /// </summary>
        Multi,
        /// <summary>
        /// Operating System (OS) style selection.
        /// </summary>
        Os,
        /// <summary>
        /// a hybrid between the os style and multi, allowing easy multi-row selection without immediate de-selection when clicking on a row.
        /// </summary>
        MultiShift
    }
}
