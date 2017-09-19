using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace Redky.AspnetCore.Mvc
{
    public class GridButtonsFactory<T> : IHtmlContent where T : class
    {
        IList<GridButtonBuilder> buttons;
        string name;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnsFactory"/>
        /// </summary>
        public GridButtonsFactory()
        {
            this.buttons = new List<GridButtonBuilder>();
        }

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
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (this.buttons.Count > 0)
            {
                writer.Write("\"buttons\":{");
                if (!string.IsNullOrEmpty(name)) writer.Write($"\"name\":'{name}',");
                writer.Write("\"buttons\":[");
                for (int i = 0; i < buttons.Count; i++)
                {
                    if (i != 0) writer.Write(",");
                    buttons[i].WriteTo(writer, encoder);
                }
                writer.Write("]},");
            }
        }
    }
}