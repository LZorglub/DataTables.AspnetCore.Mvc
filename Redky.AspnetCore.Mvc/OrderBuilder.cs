using Microsoft.AspNetCore.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;

namespace Redky.AspnetCore.Mvc
{
    public class OrderBuilder : IHtmlContent
    {
        internal ICollection<int> columns;

        public OrderBuilder()
        {
            this.columns = new HashSet<int>();
        }

        public OrderBuilder Asc(UInt16 column)
        {
            columns.Add(column);
            return this;
        }

        public OrderBuilder Desc(UInt16 column)
        {
            columns.Add(-column);
            return this;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (columns.Count() != 0)
            {
                writer.Write("\"order\":[");
                foreach (int col in columns)
                {
                    if (col < 0)
                    {
                        writer.Write($"[{-col},'desc'],");
                    }
                    else
                    {
                        writer.Write($"[{col},'asc'],");
                    }
                }
                writer.Write("]");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object value) { return base.Equals(value); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Type GetType() { return base.GetType(); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }

    }
}
