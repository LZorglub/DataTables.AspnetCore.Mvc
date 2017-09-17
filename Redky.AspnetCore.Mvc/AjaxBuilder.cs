using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace Redky.AspnetCore.Mvc
{
    public class AjaxBuilder : IHtmlContent
    {
        AjaxObject ajaxObject;

        public AjaxBuilder()
        {
            this.ajaxObject = new AjaxObject();
        }

        public AjaxBuilder Url(string url)
        {
            this.ajaxObject.Url = url;
            return this;
        }

        public AjaxBuilder Method(string method)
        {
            this.ajaxObject.Method = method;
            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("\"ajax\":{");
            writer.Write($"\"url\":\"{this.ajaxObject.Url}\",");
            if (!string.IsNullOrEmpty(this.ajaxObject.Method)) writer.Write($"\"method\":\"{this.ajaxObject.Method}\",");
            writer.Write("},");
        }
    }
}