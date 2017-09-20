using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents the language options
    /// </summary>
    public class LanguageBuilder : IHtmlContent
    {
        LanguageOptions lg;

        /// <summary>
        /// Initialize a new instance of <see cref="LanguageBuilder"/>
        /// </summary>
        public LanguageBuilder()
        {
            this.lg = new LanguageOptions();
        }

        /// <summary>
        /// Load language information from remote file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public LanguageBuilder Url(string url)
        {
            this.lg.Url = url;
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
            writer.Write("\"language\":{");
            if (!string.IsNullOrEmpty(this.lg.Url)) writer.Write($"\"url\":'{this.lg.Url}',");
            writer.Write("},");
        }
    }
}
