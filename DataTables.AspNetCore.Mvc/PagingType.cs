using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the pagingType option
    /// </summary>
    public enum PagingType
    {
        /// <summary>
        /// Page number buttons only
        /// </summary>
        Numbers,
        /// <summary>
        /// 'Previous' and 'Next' buttons only
        /// </summary>
        Simple,
        /// <summary>
        /// 'Previous' and 'Next' buttons, plus page numbers
        /// </summary>
        Simple_numbers,
        /// <summary>
        ///  'First', 'Previous', 'Next' and 'Last' buttons
        /// </summary>
        Full,
        /// <summary>
        /// 'First', 'Previous', 'Next' and 'Last' buttons, plus page numbers
        /// </summary>
        Full_numbers,
        /// <summary>
        /// 'First' and 'Last' buttons, plus page numbers
        /// </summary>
        First_last_numbers
    }
}
