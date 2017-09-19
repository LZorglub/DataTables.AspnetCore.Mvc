using System;
using System.Collections.Generic;
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
    public class GridButtonBuilder
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
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.Write("{");
            if (!string.IsNullOrEmpty(this.gridButton.Text)) writer.Write($"\"text\":'{this.gridButton.Text}',");
            if (!string.IsNullOrEmpty(this.gridButton.Extend)) writer.Write($"\"extend\":'{this.gridButton.Extend}'");
            writer.Write("}");
        }

    }
}
