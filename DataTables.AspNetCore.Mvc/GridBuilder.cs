﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a dataTable builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GridBuilder<T> : IHtmlContent where T : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridBuilder{T}"/>
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
        /// <summary>
        /// Gets or sets the <see cref="SelectBuilder"/>
        /// </summary>
        private SelectBuilder SelectBuilder { get; set; }
        /// <summary>
        /// Gets or sets the events builder
        /// </summary>
        private EventsBuilder EventsBuilder { get; set; }
        /// <summary>
        /// Gets or sets the language builder
        /// </summary>
        private LanguageBuilder LanguageBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="LengthMenuBuilder"/>
        /// </summary>
        private LengthMenuBuilder LengthMenuBuilder { get; set; }
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
        /// Grid class style
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridBuilder<T> ClassName(string className)
        {
            this.Grid.ClassName = className;
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
        /// Feature control DataTables' smart column width handling.
        /// </summary>
        /// <param name="autoWidth"></param>
        /// <returns></returns>
        public GridBuilder<T> AutoWidth(bool autoWidth)
        {
            this.Grid.AutoWidth = autoWidth;
            return this;
        }

        /// <summary>
        /// Feature control deferred rendering for additional speed of initialisation.
        /// </summary>
        /// <param name="deferRender"></param>
        /// <returns></returns>
        public GridBuilder<T> DeferRender(bool deferRender)
        {
            this.Grid.DeferRender = deferRender;
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
        /// Feature control search (filtering) abilities.
        /// </summary>
        /// <param name="searching"></param>
        /// <returns></returns>
        public GridBuilder<T> Searching(bool searching)
        {
            this.Grid.Searching = searching;
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
        /// Change the options in the page length select list.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> LengthMenu(Action<LengthMenuBuilder> config)
        {
            this.LengthMenuBuilder = new LengthMenuBuilder();
            config.Invoke(this.LengthMenuBuilder);

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
        /// <param name="serverSide"></param>
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
        /// Set the selection style for end user interaction with the table
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public GridBuilder<T> Select(Action<SelectBuilder> select)
        {
            this.SelectBuilder = new SelectBuilder();
            select.Invoke(this.SelectBuilder);
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
        /// Sets the events of dataTable
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public GridBuilder<T> Events(Action<EventsBuilder> events)
        {
            this.EventsBuilder = new EventsBuilder();
            events.Invoke(this.EventsBuilder);
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
        /// Languages options
        /// </summary>
        /// <param name="languages"></param>
        /// <returns></returns>
        public GridBuilder<T> Languages(Action<LanguageBuilder> languages)
        {
            this.LanguageBuilder = new LanguageBuilder();
            languages.Invoke(this.LanguageBuilder);

            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (string.IsNullOrEmpty(this.Grid.Name)) throw new ArgumentException("Name property required on grid.");
            bool withClick = this.ColumnsFactory != null && this.ColumnsFactory.Columns.Any(c => !string.IsNullOrEmpty(c.Column.Click));

            // Check if element Grid.Name exists
            //< script type = "text/javascript" >
            //    if ($("#example").length == 0) {
            //        document.write('<table id="example" class="display" cellspacing="0" width="100%"></table>')
            //      }
            //</ script >
            writer.Write($"<script type=\"text/javascript\">if ($(\"#{this.Grid.Name}\").length==0){{document.write('<table id=\"{this.Grid.Name}\" class=\"display{(!string.IsNullOrWhiteSpace(this.Grid.ClassName) ? $" {this.Grid.ClassName}" : "")}\" cellspacing=\"0\" width=\"100%\"></table>')}}</script>");

            // Datables.Net
            writer.Write("<script>$(function(){");
            writer.Write($"var g=$('#{this.Grid.Name}');var dt=g.DataTable(");

            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(this.Grid.RowId)) jObject.Add("rowId", new JValue(this.Grid.RowId));
            if (!string.IsNullOrEmpty(this.Grid.Dom)) jObject.Add("dom", new JValue(this.Grid.Dom));
            if (!this.Grid.AutoWidth) jObject.Add("autoWidth", new JValue(false));
            if (!this.Grid.Searching) jObject.Add("searching", new JValue(false));
            if (this.Grid.StateSave) jObject.Add("stateSave", new JValue(true));
            if (!this.Grid.Paging) jObject.Add("paging", new JValue(false));
            if (this.Grid.PagingType != DataTables.AspNetCore.Mvc.PagingType.Simple_numbers) jObject.Add($"pagingType", new JValue(this.Grid.PagingType.ToString().ToLower()));
            if (this.LengthMenuBuilder != null) jObject.Add("lengthMenu", this.LengthMenuBuilder.ToJToken());
            if (!this.Grid.Ordering) jObject.Add("ordering", new JValue(false));
            if (!this.Grid.Info) jObject.Add("info", new JValue(false));
            if (!this.Grid.OrderMulti) jObject.Add("orderMulti", new JValue(false));
            if (this.Grid.ScrollCollapse) jObject.Add("scrollCollapse", new JValue(true));
            if (this.Grid.ScrollX) jObject.Add("scrollX", new JValue(true));
            if (!string.IsNullOrEmpty(this.Grid.ScrollY)) jObject.Add($"scrollY", new JValue(this.Grid.ScrollY));
            if (this.Grid.Processing) jObject.Add("processing", new JValue(true));
            if (this.Grid.ServerSide) jObject.Add("serverSide", new JValue(true));
            if (this.Grid.DeferRender) jObject.Add("deferRender", new JValue(true));
            if (this.GridDataSourceBuilder != null) jObject.Add("ajax", this.GridDataSourceBuilder.ToJToken());
            if (this.SelectBuilder != null) jObject.Add("select", this.SelectBuilder.ToJToken());
            if (this.OrderBuilder != null) jObject.Add("order", this.OrderBuilder.ToJToken());
            if (this.LanguageBuilder != null) jObject.Add("language", this.LanguageBuilder.ToJToken());
            if (this.GridButtonsFactory != null) jObject.Add("buttons", this.GridButtonsFactory.ToJToken());
            if (this.ColumnDefsFactory != null) jObject.Add("columnDefs", this.ColumnDefsFactory.ToJToken());
            if (this.ColumnsFactory != null) jObject.Add("columns", this.ColumnsFactory.ToJToken());
            writer.Write(jObject.ToString(Newtonsoft.Json.Formatting.None));
            writer.Write(");");

            if (this.EventsBuilder != null) this.EventsBuilder.WriteTo(writer, encoder);
            if (withClick)
            {
                writer.Write("var fn=[" + string.Join(",",this.ColumnsFactory.Columns.Select(e => e.Column.Click)) + "];");
                writer.Write("g.on('click','button',function(){var row=dt.row($(this).parents('tr'));var i=dt.column($(this).parents('td')).index();if (fn.length>i){fn[i]({data:$(this).data(),rowid:row.id(),row:row.data()});}});");
                writer.Write("});</script>");
            }
            else
            {
                writer.Write("});</script>");
            }
        }
    }
}