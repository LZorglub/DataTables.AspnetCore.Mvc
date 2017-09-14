using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redky.AspnetCore.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static ComponentBuilder<TModel> Redky<TModel>(this IHtmlHelper<TModel> htmlHelper) where TModel : class
        {
            return new ComponentBuilder<TModel>(htmlHelper);
        }
    }
}
