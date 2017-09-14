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
        public GridBuilder(Grid<T> grid) 
        {
            this.Grid = grid;
        }

        public Grid<T> Grid { get; }

        public GridBuilder<T> Name(string name)
        {
            this.Grid.Name = name;
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"<p id=\" test \">hello</p>");
        }
    }
}