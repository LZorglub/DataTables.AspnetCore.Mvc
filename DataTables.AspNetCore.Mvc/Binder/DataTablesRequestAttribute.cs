using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTables.AspNetCore.Mvc.Binder
{
    /// <summary>
    /// Modelbinder for <see cref="DataTablesRequest"/>
    /// </summary>
    public class DataTablesRequestAttribute : ModelBinderAttribute
    {
        /// <summary>
        /// Initialize a new instance of <see cref="DataTablesRequestAttribute"/>
        /// </summary>
        public DataTablesRequestAttribute() : base(typeof(DataTablesRequestModelBinder))
        {

        }
    }
}
