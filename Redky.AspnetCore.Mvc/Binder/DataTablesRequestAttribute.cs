using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redky.AspnetCore.Mvc.Binder
{
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
