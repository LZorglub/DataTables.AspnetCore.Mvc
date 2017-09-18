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
        /// <summary>
        /// Initialize a new instance of <see cref="GridColumnsBuilder"/>
        /// </summary>
        public GridColumnsBuilder()
        {
            this.Column = new GridColumn();
        }

        /// <summary>
        /// Gets the internal column
        /// </summary>
        internal GridColumn Column { get; }

        /// <summary>
        /// Cell type to be created for a column.
        /// </summary>
        /// <param name="cellType"></param>
        /// <returns></returns>
        public GridColumnsBuilder CellType(CellType cellType)
        {
            this.Column.CellType = cellType;
            return this;
        }

        /// <summary>
        /// Action call when button clicked inside column
        /// </summary>
        /// <param name="cellType"></param>
        /// <returns></returns>
        public GridColumnsBuilder Click(string function)
        {
            this.Column.Click = function;
            return this;
        }

        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder ClassName(string className)
        {
            this.Column.ClassName = className;
            return this;
        }

        /// <summary>
        /// Add padding to the text content used when calculating the optimal with for a table.
        /// </summary>
        /// <param name="contentPadding"></param>
        /// <returns></returns>
        public GridColumnsBuilder ContentPadding(string contentPadding)
        {
            this.Column.ContentPadding = contentPadding;
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder Data(string data)
        {
            this.Column.Data = $"\"{data}\"";
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder Data(int data)
        {
            this.Column.Data = data.ToString();
            return this;
        }

        /// <summary>
        /// Set default, static, content for a column.
        /// </summary>
        /// <param name="defaultContent"></param>
        /// <returns></returns>
        public GridColumnsBuilder DefaultContent(string defaultContent)
        {
            this.Column.DefaultContent = defaultContent;
            return this;
        }

        /// <summary>
        /// Set a descriptive name for a column.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GridColumnsBuilder Name(string name)
        {
            this.Column.Name = name;
            return this;
        }

        /// <summary>
        /// Enable or disable ordering on this column. 
        /// </summary>
        /// <param name="orderable"></param>
        /// <returns></returns>
        public GridColumnsBuilder Orderable(bool orderable)
        {
            this.Column.Orderable = orderable;
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="column">A single column index to order upon</param>
        /// <returns></returns>
        public GridColumnsBuilder OrderData(int column)
        {
            this.Column.OrderData = column.ToString();
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="columns">Multiple column indexes to define multi-column sorting</param>
        /// <returns></returns>
        public GridColumnsBuilder OrderData(int[] columns)
        {
            this.Column.OrderData = $"[{string.Join(",", columns)}]";
            return this;
        }

        /// <summary>
        /// Live DOM sorting type assignment.
        /// </summary>
        /// <param name="orderDataType"></param>
        /// <returns></returns>
        public GridColumnsBuilder OrderDataType(string orderDataType)
        {
            this.Column.OrderDataType = orderDataType;
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="render"></param>
        /// <returns></returns>
        public GridColumnsBuilder Render(string render)
        {
            this.Column.Render = render;
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public GridColumnsBuilder Render(Func<string> function)
        {
            this.Column.Render = $"function(d,t,r,m){{return {function()}(d,t,r,m);}}";
            return this;
        }

        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        /// <param name="searchable"></param>
        /// <returns></returns>
        public GridColumnsBuilder Searchable(bool searchable)
        {
            this.Column.Searchable = searchable;
            return this;
        }

        /// <summary>
        /// Set the column title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public GridColumnsBuilder Title(string title)
        {
            this.Column.Title = title;
            return this;
        }

        /// <summary>
        /// Set the column type - used for filtering and sorting string processing.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public GridColumnsBuilder Type(string type)
        {
            this.Column.Type = type;
            return this;
        }

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public GridColumnsBuilder Visible(bool visible)
        {
            this.Column.Visible = visible;
            return this;
        }

        /// <summary>
        /// Column width assignment.
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public GridColumnsBuilder Width(string width)
        {
            this.Column.Width = width;
            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            //columns.cellType
            //columns.className
            //columns.contentPadding
            //columns.createdCell
            //columns.data
            //columns.defaultContent
            //columns.name
            //columns.orderable
            //columns.orderData
            //columns.orderDataType
            //columns.render
            //columns.searchable
            //columns.title
            //columns.type
            //columns.visible
            //columns.width

            // data and orderData are full formatted

            if (this.Column.CellType != Mvc.CellType.td) writer.Write("\"cellType\":\"tr\",");
            if (!string.IsNullOrEmpty(this.Column.ClassName)) writer.Write($"className:\"{this.Column.ClassName}\",");
            if (!string.IsNullOrEmpty(this.Column.ContentPadding)) writer.Write($"\"contentPadding\":\"{this.Column.ContentPadding}\",");
            if (!string.IsNullOrEmpty(this.Column.Data)) writer.Write($"\"data\":{this.Column.Data},");
            if (!string.IsNullOrEmpty(this.Column.DefaultContent)) writer.Write($"\"defaultContent\":\"{this.Column.DefaultContent}\",");
            if (!string.IsNullOrEmpty(this.Column.Name)) writer.Write($"\"name\":\"{this.Column.Name}\",");
            if (!this.Column.Orderable) writer.Write($"\"orderable\":\"false\",");
            if (!string.IsNullOrEmpty(this.Column.OrderData)) writer.Write($"\"orderData\":{this.Column.OrderData},");
            if (!string.IsNullOrEmpty(this.Column.OrderDataType)) writer.Write($"\"orderDataType\":\"{this.Column.OrderDataType}\",");
            if (!string.IsNullOrEmpty(this.Column.Render)) writer.Write($"\"render\":{this.Column.Render},");
            if (!this.Column.Searchable) writer.Write("searchable:false,");
            if (!string.IsNullOrEmpty(this.Column.Title)) writer.Write($"\"title\":\"{this.Column.Title}\",");
            if (!string.IsNullOrEmpty(this.Column.Type)) writer.Write($"\"type\":\"{this.Column.Type}\",");
            if (!this.Column.Visible) writer.Write("visible:false,");
            if (!string.IsNullOrEmpty(this.Column.Width)) writer.Write($"\"width\":\"{this.Column.Width}\"");
        }
    }
}
