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
    public class GridColumnsBuilder : IHtmlContent
    {
        GridColumn column;

        public GridColumnsBuilder()
        {
            this.column = new GridColumn();
        }

        public GridColumnsBuilder Searchable(bool searchable)
        {
            this.column.Searchable = searchable;
            return this;
        }

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public GridColumnsBuilder Visible(bool visible)
        {
            this.column.Visible = visible;
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="column">A single column index to order upon</param>
        /// <returns></returns>
        public GridColumnsBuilder OrderData(int column)
        {
            this.column.OrderData = column.ToString();
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="columns">Multiple column indexes to define multi-column sorting</param>
        /// <returns></returns>
        public GridColumnsBuilder OrderData(int[] columns)
        {
            this.column.OrderData = $"[{string.Join(",",columns)}]";
            return this;
        }


        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (!this.column.Visible) writer.Write("visible:false,");
            if (!this.column.Searchable) writer.Write("searchable:false,");
            if (!string.IsNullOrEmpty(this.column.OrderData)) writer.Write($"orderData:{this.column.OrderData},");
        }
    }
}
