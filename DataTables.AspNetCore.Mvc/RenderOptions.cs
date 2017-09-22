using System;
using System.Collections.Generic;
using System.Text;

namespace DataTables.AspNetCore.Mvc
{
    /// <summary>
    /// Represents options for render
    /// </summary>
    class RenderOptions
    {
        /// <summary>
        /// Initialize a new instance of <see cref="RenderOptions"/>
        /// </summary>
        public RenderOptions(RenderType renderType, string render)
        {
            this.RenderType = renderType;
            this.Render = render;
        }

        /// <summary>
        /// Gets or sets the render type 
        /// </summary>
        public RenderType RenderType { get; }

        /// <summary>
        /// Gets or sets the render value
        /// </summary>
        public string Render { get; }
    }
}
