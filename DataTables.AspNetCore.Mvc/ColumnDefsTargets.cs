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
    /// Represents columnDefs target
    /// </summary>
    public class ColumnDefsTargets : IHtmlContent
    {
        private string target;
        private GridColumnsBuilder column;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnDefsTargets"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="column"></param>
        public ColumnDefsTargets(string target, GridColumnsBuilder column)
        {
            this.target = target;
            this.column = column;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"{{targets:{target},");
            column.WriteTo(writer, encoder);
            writer.Write("}");
        }
    }
}
