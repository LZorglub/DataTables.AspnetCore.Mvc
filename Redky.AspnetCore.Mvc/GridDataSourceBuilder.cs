using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    /// <summary>
    /// Represents the grid datasource
    /// </summary>
    public class GridDataSourceBuilder : IHtmlContent
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
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (this.ajaxBuilder != null)
            {
                this.ajaxBuilder.WriteTo(writer, encoder);
            }
        }
    }
}
