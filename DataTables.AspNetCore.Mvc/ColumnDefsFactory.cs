using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents a columnDefs factory
    /// </summary>
    public class ColumnDefsFactory : IJToken
    {
        IList<ColumnDefsTargets> targets;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnDefsFactory"/>
        /// </summary>
        public ColumnDefsFactory()
        {
            this.targets = new List<ColumnDefsTargets>();
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(string className)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets($"\"{className}\"", column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(int columnIndex)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets(columnIndex.ToString(), column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnsIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder Targets(int[] columnsIndex)
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets($"[{string.Join(",",columnsIndex)}]", column));
            return column;

        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <returns></returns>
        public GridColumnsBuilder TargetAll()
        {
            GridColumnsBuilder column = new GridColumnsBuilder();
            targets.Add(new ColumnDefsTargets("\"_all\"", column));
            return column;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JArray jArray = new JArray();
            for(int i = 0; i < targets.Count; i++) 
            {
                jArray.Add(targets[i].ToJToken());
            }
            return jArray;
        }
    }
}