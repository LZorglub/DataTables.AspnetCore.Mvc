using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the grid datasource
    /// </summary>
    public class GridDataSourceBuilder : IJToken
    {
        AjaxBuilder ajaxBuilder;

        /// <summary>
        /// Initialize a new instance of <see cref="AjaxBuilder"/>
        /// </summary>
        /// <returns></returns>
        public AjaxBuilder Ajax()
        {
            this.ajaxBuilder = new AjaxBuilder();
            return this.ajaxBuilder;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            return this.ajaxBuilder?.ToJToken();
        }
    }
}
