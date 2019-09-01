using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents length menu for paging
    /// </summary>
    public class LengthMenuBuilder : IJToken
    {
        internal ICollection<Tuple<int,string>> options;

        /// <summary>
        /// Initialize a new instance of <see cref="LengthMenuBuilder"/>
        /// </summary>
        public LengthMenuBuilder()
        {
            this.options = new HashSet<Tuple<int, string>>();
        }

        /// <summary>
        /// Adds the value in length menu
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public LengthMenuBuilder Add(int value)
        {
            this.options.Add(Tuple.Create(value, value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the values in length menu
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public LengthMenuBuilder Add(int[] values)
        {
            foreach(var value in values)
                this.options.Add(Tuple.Create(value, value.ToString()));
            return this;
        }

        /// <summary>
        /// Adds the value with display value in length manu
        /// </summary>
        /// <param name="value"></param>
        /// <param name="display"></param>
        /// <returns></returns>
        public LengthMenuBuilder Add(int value, string display)
        {
            this.options.Add(Tuple.Create(value, display));
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JArray jArrayInt = new JArray();
            JArray jArrayStr = new JArray();
            foreach (var options in options)
            {
                jArrayInt.Add(options.Item1);
                jArrayStr.Add(options.Item2);
            }
            return new JArray(jArrayInt, jArrayStr); ;
        }
    }
}
