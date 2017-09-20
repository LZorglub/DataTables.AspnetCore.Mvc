using System;
using System.Collections.Generic;
using System.Text;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents built-in button
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// Export excel
        /// </summary>
        Excel,
        /// <summary>
        /// Print
        /// </summary>
        Print,
        /// <summary>
        /// Copy
        /// </summary>
        Copy,
        /// <summary>
        /// Selected button provide by Select extension
        /// </summary>
        Selected
    }
}
