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
    /// Represents a grid column builder
    /// </summary>
    public class GridColumnsBuilder : IJToken
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridColumnsBuilder"/>
        /// </summary>
        public GridColumnsBuilder()
        {
            this.Column = new GridColumnOptions();
        }

        /// <summary>
        /// Gets the internal column
        /// </summary>
        internal GridColumnOptions Column { get; }

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
        /// <param name="function"></param>
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
            this.Column.Data = data;
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder Data(int data)
        {
            this.Column.Data = data;
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
            this.Column.OrderData = new int[] { column };
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="columns">Multiple column indexes to define multi-column sorting</param>
        /// <returns></returns>
        public GridColumnsBuilder OrderData(int[] columns)
        {
            this.Column.OrderData = columns;
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
            this.Column.Render = new RenderOptions(RenderType.String, render);
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public GridColumnsBuilder Render(Func<string> function)
        {
            this.Column.Render = new RenderOptions(RenderType.Function, $"function(d,t,r,m){{return {function()}(d,t,r,m);}}");
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
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
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
            JObject jObject = new JObject();
            if (this.Column.CellType != Mvc.CellType.td) jObject.Add("cellType", new JValue("tr"));
            if (!string.IsNullOrEmpty(this.Column.ClassName)) jObject.Add("className", new JValue(this.Column.ClassName));
            if (!string.IsNullOrEmpty(this.Column.ContentPadding)) jObject.Add("contentPadding", new JValue(this.Column.ContentPadding));
            // data is string or int
            if (this.Column.Data != null) jObject.Add("data", new JValue(this.Column.Data));
            if (!string.IsNullOrEmpty(this.Column.DefaultContent)) jObject.Add("defaultContent", new JValue(this.Column.DefaultContent));
            if (!string.IsNullOrEmpty(this.Column.Name)) jObject.Add("name", new JValue(this.Column.Name));
            if (!this.Column.Orderable) jObject.Add("orderable", new JValue(false));
            // int[]
            if (this.Column.OrderData != null) jObject.Add("orderData", new JArray(this.Column.OrderData));
            if (!string.IsNullOrEmpty(this.Column.OrderDataType)) jObject.Add("orderDataType", new JValue(this.Column.OrderDataType));
            if (this.Column.Render != null)
            {
                if (this.Column.Render.RenderType == RenderType.String)
                {
                    // Template
                    if (this.Column.Render.Render == null)
                    {
                        jObject.Add("render", new JRaw("null"));
                    }
                    else
                    {
                        jObject.Add("render", new JValue(this.Column.Render.Render));
                    }
                } else if (this.Column.Render.RenderType == RenderType.Function)
                {
                    // Function
                    jObject.Add("render", new JRaw(this.Column.Render.Render));
                }
            }
            if (!this.Column.Searchable) jObject.Add("searchable", new JValue(false));
            if (!string.IsNullOrEmpty(this.Column.Title)) jObject.Add("title", new JValue(this.Column.Title));
            if (!string.IsNullOrEmpty(this.Column.Type)) jObject.Add("type", new JValue(this.Column.Type));
            if (!this.Column.Visible) jObject.Add("visible", new JValue(false));
            if (!string.IsNullOrEmpty(this.Column.Width)) jObject.Add("width", new JValue(this.Column.Width));
            return jObject;
        }
    }
}
