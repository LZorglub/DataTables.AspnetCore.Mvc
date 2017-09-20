using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Provides HtmlHelper extensions
    /// </summary>
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Extension to controls
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static ControlBuilder<TModel> Ext<TModel>(this IHtmlHelper<TModel> htmlHelper) where TModel : class
        {
            return new ControlBuilder<TModel>(htmlHelper);
        }
    }
}
