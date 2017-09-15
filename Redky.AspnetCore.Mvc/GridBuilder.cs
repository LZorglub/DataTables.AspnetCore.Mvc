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
            if (this.OrderBuilder != null) this.OrderBuilder.WriteTo(writer, encoder);
            if (this.ColumnDefsFactory != null) this.ColumnDefsFactory.WriteTo(writer, encoder);
            writer.Write("});");
            writer.Write("});</script>");
        }
    }
}