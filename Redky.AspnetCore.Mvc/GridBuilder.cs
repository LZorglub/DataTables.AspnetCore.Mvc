using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    public class GridBuilder<T> : IHtmlContent where T : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridBuilder"/>
        /// </summary>
        /// <param name="grid"></param>
        public GridBuilder(Grid<T> grid) 
        {
            this.Grid = grid;
        }

        /// <summary>
        /// Gets the undelying <see cref="Grid{T}"/>
        /// </summary>
        public Grid<T> Grid { get; }

        private OrderBuilder OrderBuilder { get; set; }
        private ColumnDefsFactory ColumnDefsFactory { get; set; }
        private GridDataSourceBuilder GridDataSourceBuilder { get; set; }
        private ColumnsFactory ColumnsFactory { get; set; }

        /// <summary>
        /// Grid name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GridBuilder<T> Name(string name)
        {
            this.Grid.Name = name;
            return this;
        }

        /// <summary>
        /// Define the table control elements to appear on the page and in what order.
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public GridBuilder<T> Dom(string dom)
        {
            this.Grid.Dom = dom;
            return this;
        }

        /// <summary>
        /// Initial order (sort) to apply to the table.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Order(Action<OrderBuilder> config)
        {
            this.OrderBuilder = new OrderBuilder();
            config.Invoke(this.OrderBuilder);

            return this;
        }

        /// <summary>
        /// State saving - restore table state on page reload.
        /// </summary>
        /// <param name="stateSave"></param>
        /// <returns></returns>
        public GridBuilder<T> StateSave(bool stateSave)
        {
            this.Grid.StateSave = stateSave;
            return this;
        }

        /// <summary>
        /// Enable or disable table pagination.
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        public GridBuilder<T> Paging(bool paging)
        {
            this.Grid.Paging = paging;
            return this;
        }

        /// <summary>
        /// Pagination button display options.
        /// </summary>
        /// <param name="pagingType"></param>
        /// <returns></returns>
        public GridBuilder<T> PagingType(PagingType pagingType)
        {
            this.Grid.PagingType = pagingType;
            return this;
        }

        /// <summary>
        /// Feature control ordering (sorting) abilities in DataTables.
        /// </summary>
        /// <param name="ordering"></param>
        /// <returns></returns>
        public GridBuilder<T> Ordering(bool ordering)
        {
            this.Grid.Ordering = ordering;
            return this;
        }

        /// <summary>
        /// Feature control table information display field.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public GridBuilder<T> Info(bool info)
        {
            this.Grid.Info = info;
            return this;
        }

        /// <summary>
        /// Multiple column ordering ability control.
        /// </summary>
        /// <param name="orderMulti"></param>
        /// <returns></returns>
        public GridBuilder<T> OrderMulti(bool orderMulti)
        {
            this.Grid.OrderMulti = orderMulti;
            return this;
        }

        /// <summary>
        /// Allow the table to reduce in height when a limited number of rows are shown.
        /// </summary>
        /// <param name="scrollCollapse"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollCollapse(bool scrollCollapse)
        {
            this.Grid.ScrollCollapse = scrollCollapse;
            return this;
        }

        /// <summary>
        /// Horizontal scrolling.
        /// </summary>
        /// <param name="scrollX"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollX(bool scrollX)
        {
            this.Grid.ScrollX = scrollX;
            return this;
        }

        /// <summary>
        /// Vertical scrolling.
        /// </summary>
        /// <param name="scrollY"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollY(string scrollY)
        {
            this.Grid.ScrollY = scrollY;
            return this;
        }

        /// <summary>
        /// Feature control the processing indicator.
        /// </summary>
        /// <param name="processing"></param>
        /// <returns></returns>
        public GridBuilder<T> Processing(bool processing)
        {
            this.Grid.Processing = processing;
            return this;
        }

        /// <summary>
        /// Feature control DataTables' server-side processing mode.
        /// </summary>
        /// <param name="processing"></param>
        /// <returns></returns>
        public GridBuilder<T> ServerSide(bool serverSide)
        {
            this.Grid.ServerSide = serverSide;
            return this;
        }

        /// <summary>
        /// Set columns.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Columns(Action<ColumnsFactory> config)
        {
            this.ColumnsFactory = new ColumnsFactory();
            config.Invoke(this.ColumnsFactory);

            return this;
        }

        /// <summary>
        /// Set column definition initialisation properties.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> ColumnDefs(Action<ColumnDefsFactory> config)
        {
            this.ColumnDefsFactory = new ColumnDefsFactory();
            config.Invoke(this.ColumnDefsFactory);

            return this;
        }

        /// <summary>
        /// DataSources
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> DataSource(Action<GridDataSourceBuilder> config)
        {
            this.GridDataSourceBuilder = new GridDataSourceBuilder();
            config.Invoke(this.GridDataSourceBuilder);

            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("<script>$(function(){");
            writer.Write($"$('#{this.Grid.Name}').DataTable({{");
            if (!string.IsNullOrEmpty(this.Grid.Dom)) writer.Write($"\"dom\":'{this.Grid.Dom}',");
            if (this.Grid.StateSave) writer.Write("\"stateSave\":true,");
            if (!this.Grid.Paging) writer.Write("\"paging\":false,");
            if (this.Grid.PagingType != Redky.AspnetCore.Mvc.PagingType.Simple_numbers) writer.Write($"\"pagingType\":\"{this.Grid.PagingType.ToString().ToLower()}\",");
            if (!this.Grid.Ordering) writer.Write("\"ordering\":false,");
            if (!this.Grid.Info) writer.Write("\"info\":false,");
            if (!this.Grid.OrderMulti) writer.Write("\"orderMulti\":false,");
            if (this.Grid.ScrollCollapse) writer.Write("\"scrollCollapse\":true,");
            if (this.Grid.ScrollX) writer.Write("\"scrollX\":true,");
            if (!string.IsNullOrEmpty(this.Grid.ScrollY)) writer.Write($"\"scrollY\":\"{this.Grid.ScrollY}\",");
            if (this.Grid.Processing) writer.Write("\"processing\":true,");
            if (this.Grid.ServerSide) writer.Write("\"serverSide\":true,");
            if (this.OrderBuilder != null) this.OrderBuilder.WriteTo(writer, encoder);
            if (this.ColumnsFactory!= null) this.ColumnsFactory.WriteTo(writer, encoder);
            if (this.ColumnDefsFactory != null) this.ColumnDefsFactory.WriteTo(writer, encoder);
            if (this.GridDataSourceBuilder != null) this.GridDataSourceBuilder.WriteTo(writer, encoder);

            writer.Write("});");
            writer.Write("});</script>");
        }
    }
}