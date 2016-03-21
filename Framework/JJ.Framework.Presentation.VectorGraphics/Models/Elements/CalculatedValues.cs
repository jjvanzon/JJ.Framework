using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> 
    /// Read-only public explicit interface so that the main interface is not obscured
    /// for accessing calculated values derived from the main properties.
    ///  <summary>
    public class CalculatedValues
    {
        /// <summary> The calculated ZIndex, which is derived from both the ZIndex and the containment structure. </summary>
        public int ZIndex { get; internal set; }
        public float XInPixels { get; internal set; }
        public float YInPixels { get; internal set; }
        public float WidthInPixels { get; internal set; }
        public float HeightInPixels { get; internal set; }
        public int Layer { get; internal set; }
        public bool Visible { get; internal set; }
        public bool Enabled { get; internal set; }
    }
}
