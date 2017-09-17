using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using System.Collections;
using System.Collections.Generic;

namespace Redky.AspnetCore.Mvc
{
    public class ColumnDefsFactory : IHtmlContent
    {
        IList<ColumnDefsTargets> targets;

        public ColumnDefsFactory()
        {
            this.targets = new List<ColumnDefsTargets>();
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(string className)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets($"'{className}'", column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(int columnIndex)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets(columnIndex.ToString(), column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnsIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(int[] columnsIndex)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets($"[{string.Join(",",columnsIndex)}]", column));
            return column;

        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <returns></returns>
        public GridColumnsBuilder TargetAll()
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets("'_all'", column));
            return column;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("\"columnDefs\":[");
            for(int i = 0; i < targets.Count; i++) 
            {
                if (i != 0) writer.Write(",");
                targets[i].WriteTo(writer, encoder);
            }
            writer.Write("],");
        }
    }
}