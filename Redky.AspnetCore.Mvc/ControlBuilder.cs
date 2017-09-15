using Microsoft.AspNetCore.Mvc.Rendering;

namespace Redky.AspnetCore.Mvc
{
    public class ControlBuilder<TModel> where TModel : class
    {
        public ControlBuilder(IHtmlHelper<TModel> htmlHelper)
        {
            this.HtmlHelper = htmlHelper;
        }

        public IHtmlHelper<TModel> HtmlHelper { get; private set; }

        public GridBuilder<T> Grid<T>() where T : class
        {
            return new GridBuilder<T>(new Grid<T>());
        }
    }
}