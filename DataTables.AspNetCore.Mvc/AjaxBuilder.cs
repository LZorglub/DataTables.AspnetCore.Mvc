using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a builder for ajax options
    /// </summary>
    public class AjaxBuilder : IJToken
    {
        AjaxOptions ajaxObject;

        /// <summary>
        /// Initialize a new instance of <see cref="AjaxBuilder"/>
        /// </summary>
        public AjaxBuilder()
        {
            this.ajaxObject = new AjaxOptions();
        }

        /// <summary>
        /// Sets tha ajax url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public AjaxBuilder Url(string url)
        {
            this.ajaxObject.Url = url;
            return this;
        }

        /// <summary>
        /// Sets the ajax method
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public AjaxBuilder Method(string method)
        {
            this.ajaxObject.Method = method;
            return this;
        }

        /// <summary>
        /// Data property or manipulation method for table data.
        /// </summary>
        /// <param name="dataSrc"></param>
        /// <returns></returns>
        public AjaxBuilder DataSrc(string dataSrc)
        {
            this.ajaxObject.DataSrc = dataSrc;
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JObject jObject = new JObject();
            jObject.Add("url", new JValue(this.ajaxObject.Url));
            if (!string.IsNullOrEmpty(this.ajaxObject.Method)) jObject.Add("method", new JValue(this.ajaxObject.Method));
            if (this.ajaxObject.DataSrc != null) jObject.Add("dataSrc",new JValue(this.ajaxObject.DataSrc));

            return jObject;
        }
    }
}