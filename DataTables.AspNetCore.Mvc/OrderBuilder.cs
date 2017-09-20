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
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents order of columns
    /// </summary>
    public class OrderBuilder : IJToken
    {
        internal ICollection<int> columns;

        /// <summary>
        /// Initialize a new isntance of <see cref="OrderBuilder"/>
        /// </summary>
        public OrderBuilder()
        {
            this.columns = new HashSet<int>();
        }

        /// <summary>
        /// Direction so order to apply (asc for ascending order or desc for descending order).
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public OrderBuilder Asc(UInt16 column)
        {
            columns.Add(column);
            return this;
        }

        /// <summary>
        /// Direction so order to apply (asc for ascending order or desc for descending order).
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public OrderBuilder Desc(UInt16 column)
        {
            columns.Add(-column);
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JArray jArray = new JArray();
            foreach(int col in columns)
            {
                if (col < 0)
                    jArray.Add(new JArray(new JValue(-col), new JValue("desc")));
                else
                    jArray.Add(new JArray(new JValue(col), new JValue("asc")));
            }
            return jArray;
        }

        #region Hide object method 
        /// <summary>
        /// Determines whether the specified object is equal to the current object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object value) { return base.Equals(value); }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() { return base.GetHashCode(); }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() { return base.ToString(); }
        #endregion
    }
}
