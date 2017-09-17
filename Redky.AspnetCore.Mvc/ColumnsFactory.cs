using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    public class ColumnsFactory : IHtmlContent
    {
        IList<GridColumnsBuilder> columns;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnsFactory"/>
        /// </summary>
        public ColumnsFactory()
        {
            this.columns = new List<GridColumnsBuilder>();
        }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <returns></returns>
        public GridColumnsBuilder Add()
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            this.columns.Add(column);
            return column;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("\"columns\":[");
            for (int i = 0; i < columns.Count; i++)
            {
                if (i != 0) writer.Write(",");
                writer.Write("{");
                columns[i].WriteTo(writer, encoder);
                writer.Write("}");
            }
            writer.Write("],");
        }
    }
}
