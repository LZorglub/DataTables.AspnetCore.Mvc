using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents an ajax object
    /// </summary>
    class AjaxOptions
    {
        /// <summary>
        /// Gets or sets ajax url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the ajax method
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Data property or manipulation method for table data.
        /// </summary>
        public string DataSrc { get; set; }
    }
}
