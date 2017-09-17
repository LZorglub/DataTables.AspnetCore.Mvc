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

        /// <summary>
        /// Initialize a new instance of <see cref="GridColumnsBuilder"/>
        /// </summary>
        public GridColumnsBuilder()
        {
            this.column = new GridColumn();
        }

        /// <summary>
        /// Cell type to be created for a column.
        /// </summary>
        /// <param name="cellType"></param>
        /// <returns></returns>
        public GridColumnsBuilder CellType(CellType cellType)
        {
            this.column.CellType = cellType;
            return this;
        }

        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder ClassName(string className)
        {
            this.column.ClassName = className;
            return this;
        }

        /// <summary>
        /// Add padding to the text content used when calculating the optimal with for a table.
        /// </summary>
        /// <param name="contentPadding"></param>
        /// <returns></returns>
        public GridColumnsBuilder ContentPadding(string contentPadding)
        {
            this.column.ContentPadding = contentPadding;
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder Data(string data)
        {
            this.column.Data = $"\"{data}\"";
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder Data(int data)
        {
            this.column.Data = data.ToString();
            return this;
        }

        /// <summary>
        /// Set default, static, content for a column.
        /// </summary>
        /// <param name="defaultContent"></param>
        /// <returns></returns>
        public GridColumnsBuilder DefaultContent(string defaultContent)
        {
            this.column.DefaultContent = defaultContent;
            return this;
        }

        /// <summary>
        /// Set a descriptive name for a column.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GridColumnsBuilder Name(string name)
        {
            this.column.Name = name;
            return this;
        }

        /// <summary>
        /// Enable or disable ordering on this column. 
        /// </summary>
        /// <param name="orderable"></param>
        /// <returns></returns>
        public GridColumnsBuilder Orderable(bool orderable)
        {
            this.column.Orderable = orderable;
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
            this.column.OrderData = $"[{string.Join(",", columns)}]";
            return this;
        }

        /// <summary>
        /// Live DOM sorting type assignment.
        /// </summary>
        /// <param name="orderDataType"></param>
        /// <returns></returns>
        public GridColumnsBuilder OrderDataType(string orderDataType)
        {
            this.column.OrderDataType = orderDataType;
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="render"></param>
        /// <returns></returns>
        public GridColumnsBuilder Render(string render)
        {
            this.column.Render = render;
            return this;
        }

        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        /// <param name="searchable"></param>
        /// <returns></returns>
        public GridColumnsBuilder Searchable(bool searchable)
        {
            this.column.Searchable = searchable;
            return this;
        }

        /// <summary>
        /// Set the column title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public GridColumnsBuilder Title(string title)
        {
            this.column.Title = title;
            return this;
        }

        /// <summary>
        /// Set the column type - used for filtering and sorting string processing.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public GridColumnsBuilder Type(string type)
        {
            this.column.Type = type;
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
        /// Column width assignment.
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public GridColumnsBuilder Width(string width)
        {
            this.column.Width = width;
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

            if (this.column.CellType != Mvc.CellType.td) writer.Write("\"cellType\":\"tr\",");
            if (!string.IsNullOrEmpty(this.column.ClassName)) writer.Write($"className:\"{this.column.ClassName}\",");
            if (!string.IsNullOrEmpty(this.column.ContentPadding)) writer.Write($"\"contentPadding\":\"{this.column.ContentPadding}\",");
            if (!string.IsNullOrEmpty(this.column.Data)) writer.Write($"\"data\":{this.column.Data},");
            if (!string.IsNullOrEmpty(this.column.DefaultContent)) writer.Write($"\"defaultContent\":\"{this.column.DefaultContent}\",");
            if (!string.IsNullOrEmpty(this.column.Name)) writer.Write($"\"name\":\"{this.column.Name}\",");
            if (!this.column.Orderable) writer.Write($"\"orderable\":\"false\",");
            if (!string.IsNullOrEmpty(this.column.OrderData)) writer.Write($"\"orderData\":{this.column.OrderData},");
            if (!string.IsNullOrEmpty(this.column.OrderDataType)) writer.Write($"\"orderDataType\":\"{this.column.OrderDataType}\",");
            if (!string.IsNullOrEmpty(this.column.Render)) writer.Write($"\"render\":\"{this.column.Render}\",");
            if (!this.column.Searchable) writer.Write("searchable:false,");
            if (!string.IsNullOrEmpty(this.column.Title)) writer.Write($"\"title\":\"{this.column.Title}\",");
            if (!string.IsNullOrEmpty(this.column.Type)) writer.Write($"\"type\":\"{this.column.Type}\",");
            if (!this.column.Visible) writer.Write("visible:false,");
            if (!string.IsNullOrEmpty(this.column.Width)) writer.Write($"\"width\":\"{this.column.Width}\"");
        }
    }
}
