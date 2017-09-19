using Microsoft.AspNetCore.Mvc.Rendering;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a control builder
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ControlBuilder<TModel> where TModel : class
    {
        /// <summary>
        /// Initialize a new insntance of <see cref="ControlBuilder{TModel}"/>
        /// </summary>
        /// <param name="htmlHelper"></param>
        public ControlBuilder(IHtmlHelper<TModel> htmlHelper)
        {
            this.HtmlHelper = htmlHelper;
        }

        /// <summary>
        /// Gets or sets the <see cref="IHtmlHelper{TModel}"/>
        /// </summary>
        public IHtmlHelper<TModel> HtmlHelper { get; private set; }

        /// <summary>
        /// Gets a <see cref="GridBuilder{T}"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GridBuilder<T> Grid<T>() where T : class
        {
            return new GridBuilder<T>();
        }
    }
}