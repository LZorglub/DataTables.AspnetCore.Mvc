using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    public class ColumnsFactory<TModel> : IHtmlContent where TModel : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ColumnsFactory"/>
        /// </summary>
        public ColumnsFactory()
        {
            this.Columns = new List<GridColumnsBuilder>();
        }

        /// <summary>
        /// Gets the list of columns
        /// </summary>
        internal IList<GridColumnsBuilder> Columns { get; }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GridColumnsBuilder Add<T>()
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            this.Columns.Add(column);
            return column;
        }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public GridColumnsBuilder Add<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));
            GridColumnsBuilder column = new GridColumnsBuilder();
            this.Columns.Add(column.Data(propertyName));
            return column;
        }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public GridColumnsBuilder Add<T>(Expression<Func<TModel, T>> expression)
        {
            var p = PropertyBuilder.GetPropertyInfo(expression);
            string pName = PropertyBuilder.GetPropertyName(p);

            GridColumnsBuilder column = new GridColumnsBuilder();
            this.Columns.Add(column.Data(pName));
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
            for (int i = 0; i < Columns.Count; i++)
            {
                if (i != 0) writer.Write(",");
                writer.Write("{");
                Columns[i].WriteTo(writer, encoder);
                writer.Write("}");
            }
            writer.Write("],");
        }
    }
}
