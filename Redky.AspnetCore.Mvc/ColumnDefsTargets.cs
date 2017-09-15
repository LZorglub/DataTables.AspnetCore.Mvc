using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    public class ColumnDefsTargets : IHtmlContent
    {
        private string target;
        private GridColumnsBuilder column;

        public ColumnDefsTargets(string target, GridColumnsBuilder column)
        {
            this.target = target;
            this.column = column;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write($"{{targets:{target},");
            column.WriteTo(writer, encoder);
            writer.Write("}");
        }
    }
}
