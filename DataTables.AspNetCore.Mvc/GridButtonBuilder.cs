using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a grid header button builder
    /// </summary>
    public class GridButtonBuilder : IJToken
    {
        GridButtonOptions gridButton;

        /// <summary>
        /// Initialize a new instance of <see cref="GridButtonBuilder"/>
        /// </summary>
        public GridButtonBuilder()
        {
            this.gridButton = new GridButtonOptions();
        }

        /// <summary>
        /// Define which button type the button should be based on. 
        /// </summary>
        /// <param name="extend"></param>
        /// <returns></returns>
        public GridButtonBuilder Extend(ButtonType extend)
        {
            this.gridButton.Extend = extend.ToString().ToLower();
            return this;
        }

        /// <summary>
        /// Action to take when the button is activated.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public GridButtonBuilder Action(Func<string> action)
        {
            this.gridButton.Action = action();
            return this;
        }

        /// <summary>
        /// The text to show in the button
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public GridButtonBuilder Text(string text)
        {
            this.gridButton.Text = text;
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
            if (!string.IsNullOrEmpty(this.gridButton.Text)) jObject.Add("text", new JValue(this.gridButton.Text));
            if (!string.IsNullOrEmpty(this.gridButton.Extend)) jObject.Add("extend", new JValue(this.gridButton.Extend));
            if (!string.IsNullOrEmpty(this.gridButton.Action)) jObject.Add("action", new JRaw($"function(e,dt,node,config){{{this.gridButton.Action}(e,dt,node,config);}}"));
            return jObject;
        }

    }
}
