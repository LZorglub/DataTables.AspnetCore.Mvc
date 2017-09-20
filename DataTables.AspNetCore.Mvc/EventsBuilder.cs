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
    /// Represents the events builder
    /// </summary>
    public class EventsBuilder : IHtmlContent
    {
        Dictionary<string, IList<string>> events;

        /// <summary>
        /// Initialize a new instance of <see cref="EventsBuilder"/>
        /// </summary>
        public EventsBuilder()
        {
            this.events = new Dictionary<string, IList<string>>();
        }

        /// <summary>
        /// Adds or updates the event in events list
        /// </summary>
        /// <param name="key"></param>
        /// <param name="parameters"></param>
        /// <param name="fn"></param>
        private void Add(string key, string parameters, string fn)
        {
            if (!this.events.ContainsKey(key))
            {
                this.events.Add(key, new List<string>());
                this.events[key].Add(parameters);
            }
            this.events[key].Add(fn);
        }

        /// <summary>
        /// Items (rows, columns or cells) have been selected.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventsBuilder Select(string name)
        {
            this.Add("select", "(e,dt,type,indexes)", name);
            return this;
        }

        /// <summary>
        /// Items(rows, columns or cells) have been deselected
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventsBuilder Deselect(string name)
        {
            this.Add("deselect", "(e,dt,type,indexes)", name);
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
            //table.on('select', function(e, dt, type, indexes) {
            //    if (type === 'row')
            //    {
            //        var data = table.rows(indexes).data().pluck('id');

            //        // do something with the ID of the selected items
            //    }
            //} );
            var ienum = events.GetEnumerator();
            while(ienum.MoveNext())
            {
                IList<string> functions = ienum.Current.Value;
                writer.Write($"dt.on('{ienum.Current.Key}',function{functions[0]}{{");
                for (int i = 1; i < functions.Count; i++)
                    writer.Write($"{functions[i]}{functions[0]};");
                writer.Write("});");
            }
        }
    }
}
