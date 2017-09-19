using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using System.Linq;

namespace Redky.AspnetCore.Mvc
{
    public class GridBuilder<T> : IHtmlContent where T : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridBuilder"/>
        /// </summary>
        public GridBuilder() 
        {
            this.Grid = new GridOptions<T>();
        }

        #region Properties
        /// <summary>
        /// Gets the undelying <see cref="GridOptions{T}"/>
        /// </summary>
        internal GridOptions<T> Grid { get; }
        /// <summary>
        /// Gets or sets the <see cref="OrderBuilder"/>
        /// </summary>
        private OrderBuilder OrderBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ColumnDefsFactory"/>
        /// </summary>
        private ColumnDefsFactory ColumnDefsFactory { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="GridDataSourceBuilder"/>
        /// </summary>
        private GridDataSourceBuilder GridDataSourceBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ColumnsFactory"/>
        /// </summary>
        private ColumnsFactory<T> ColumnsFactory { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="GridButtonsFactory"/>
        /// </summary>
        private GridButtonsFactory<T> GridButtonsFactory { get; set; }
        #endregion

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
        /// Data property name that DataTables will use to set tr element DOM IDs.
        /// </summary>
        /// <param name="rowId"></param>
        /// <returns></returns>
        public GridBuilder<T> RowId(string rowId)
        {
            this.Grid.RowId = rowId;
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
        public GridBuilder<T> Columns(Action<ColumnsFactory<T>> config)
        {
            this.ColumnsFactory = new ColumnsFactory<T>();
            config.Invoke(this.ColumnsFactory);

            return this;
        }

        /// <summary>
        /// Buttons configuration object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Buttons(string name, Action<GridButtonsFactory<T>> config)
        {
            this.GridButtonsFactory = new GridButtonsFactory<T>(name);
            config.Invoke(this.GridButtonsFactory);

            return this;
        }

        /// <summary>
        /// Buttons configuration object.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Buttons(Action<GridButtonsFactory<T>> config)
        {
            this.GridButtonsFactory = new GridButtonsFactory<T>();
            config.Invoke(this.GridButtonsFactory);

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
            bool withClick = this.ColumnsFactory != null && this.ColumnsFactory.Columns.Any(c => !string.IsNullOrEmpty(c.Column.Click));

            // Check if element Grid.Name exists
            //< script type = "text/javascript" >
            //    if ($("#example").length == 0) {
            //        document.write('<table id="example" class="display" cellspacing="0" width="100%"></table>')
            //      }
            //</ script >
            writer.Write($"<script type=\"text/javascript\">if ($(\"{this.Grid.Name}\").length==0){{document.write('<table id=\"{this.Grid.Name}\" class=\"display\" cellspacing=\"0\" width=\"100%\"></table>')}}</script>");

            // Datables.Net
            writer.Write("<script>$(function(){");
            if (withClick)
            {
                writer.Write($"var grid=$('#{this.Grid.Name}');var dt=grid.DataTable({{");
            } else
            {
                writer.Write($"$('#{this.Grid.Name}').DataTable({{");
            }
            if (!string.IsNullOrEmpty(this.Grid.RowId)) writer.Write($"\"rowId\":'{this.Grid.RowId}',");
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
            if (this.GridButtonsFactory != null) this.GridButtonsFactory.WriteTo(writer, encoder);
            if (this.ColumnsFactory!= null) this.ColumnsFactory.WriteTo(writer, encoder);
            if (this.ColumnDefsFactory != null) this.ColumnDefsFactory.WriteTo(writer, encoder);
            if (this.GridDataSourceBuilder != null) this.GridDataSourceBuilder.WriteTo(writer, encoder);

            writer.Write("});");

            if (withClick)
            {
                writer.Write("var fn=[" + string.Join(",",this.ColumnsFactory.Columns.Select(e => e.Column.Click)) + "];");
                writer.Write("grid.on('click','button',function(){var row=dt.row($(this).parents('tr'));var i=dt.column($(this).parents('td')).index();if (fn.length>i){fn[i]({data:$(this).data(),rowid:row.id(),row:row.data()});}});");
                writer.Write("});</script>");
            }
            else
            {
                writer.Write("});</script>");
            }
        }
    }
}