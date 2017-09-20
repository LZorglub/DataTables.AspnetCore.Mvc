using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the select xtension builder
    /// </summary>
    public class SelectBuilder : IHtmlContent
    {
        SelectOptions select;

        /// <summary>
        /// Initialize a new instance of <see cref="SelectBuilder"/>
        /// </summary>
        public SelectBuilder()
        {
            this.select = new SelectOptions();
        }

        /// <summary>
        /// Indicate if the selected items will be removed when clicking outside of the table
        /// </summary>
        /// <param name="blurable"></param>
        /// <returns></returns>
        public SelectBuilder Blurable(bool blurable)
        {
            this.select.Blurable = blurable;
            return this;
        }

        /// <summary>
        /// Set the class name that will be applied to selected items
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public SelectBuilder ClassName(string className)
        {
            this.select.ClassName = className;
            return this;
        }

        /// <summary>
        /// Enable / disable the display for item selection information in the table summary.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public SelectBuilder Info(bool info)
        {
            this.select.Info = info;
            return this;
        }

        /// <summary>
        /// Set which table items to select (rows, columns or cells)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public SelectBuilder Items(SelectItemsType items)
        {
            this.select.Items = items;
            return this;
        }

        /// <summary>
        /// Set the selection style for end user interaction with the table.
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public SelectBuilder Style(SelectStyle style)
        {
            this.select.Style = style;
            return this;
        }

        /// <summary>
        /// Set the element selector used for mouse event capture to select items. 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public SelectBuilder Selector(string selector)
        {
            this.select.Selector = selector;
            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("\"select\":{");
            if (this.select.Style == SelectStyle.MultiShift)
            {
                writer.Write($"style:'multi+shift',");
            }
            else
            {
                writer.Write($"style:'{this.select.Style.ToString().ToLower()}',");
            }
            if (this.select.Blurable) writer.Write("blurable:true,");
            if (!string.IsNullOrEmpty(this.select.ClassName)) writer.Write($"className:'{this.select.ClassName}',");
            if (!this.select.Info) writer.Write("info:false,");
            if (this.select.Items != SelectItemsType.Row) writer.Write($"items:'{this.select.Items.ToString().ToLower()}',");
            if (!string.IsNullOrEmpty(this.select.Selector)) { writer.Write($"selector:'{this.select.Selector}',"); }
            writer.Write("},");
        }
    }
}
