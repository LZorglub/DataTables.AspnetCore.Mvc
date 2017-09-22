using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Encodings.Web;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a factory of grid button
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GridButtonsFactory<T> : IJToken where T : class
    {
        IList<GridButtonBuilder> buttons;
        string name;

        /// <summary>
        /// Initialize a new instance of <see cref="GridButtonsFactory{T}"/>
        /// </summary>
        public GridButtonsFactory()
        {
            this.buttons = new List<GridButtonBuilder>();
        }

        /// <summary>
        /// Initialize a new instance of <see cref="GridButtonsFactory{T}"/>
        /// </summary>
        /// <param name="name"></param>
        public GridButtonsFactory(string name) : this()
        {
            this.name = name;
        }

        /// <summary>
        /// Add a button to the factory
        /// </summary>
        /// <param name="buttonType"></param>
        /// <returns></returns>
        public GridButtonBuilder Add(ButtonType buttonType)
        {
            GridButtonBuilder button = new GridButtonBuilder();
            button.Extend(buttonType);
            this.buttons.Add(button);

            return button;
        }

        /// <summary>
        /// Add a button to the factory
        /// </summary>
        /// <param name="text">Button text</param>
        /// <returns></returns>
        public GridButtonBuilder Add(string text)
        {
            GridButtonBuilder button = new GridButtonBuilder();
            this.buttons.Add(button.Text(text));

            return button;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JObject jObject = new JObject();
            if (this.buttons.Count > 0)
            {
                if (!string.IsNullOrEmpty(name)) jObject.Add("name", name);
                JArray jArray = new JArray();
                for (int i = 0; i < buttons.Count; i++)
                {
                    jArray.Add(buttons[i].ToJToken());
                }
                jObject.Add("buttons", jArray);
            }
            return jObject;
        }
    }
}