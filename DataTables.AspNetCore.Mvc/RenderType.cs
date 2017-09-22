using System;
using System.Collections.Generic;
using System.Text;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the type of column rendering
    /// </summary>
    enum RenderType
    {
        /// <summary>
        /// Represents a string render
        /// </summary>
        String,
        /// <summary>
        /// Represents a javascript function
        /// </summary>
        Function
    }
}
