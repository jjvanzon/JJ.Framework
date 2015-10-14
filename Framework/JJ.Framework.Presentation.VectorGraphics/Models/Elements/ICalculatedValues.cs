using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.VectorGraphics.Models.Elements
{
    /// <summary> read-only calculated values derived from the main properties. summary>
    public interface ICalculatedValues
    {
        /// <summary> The calculated ZIndex, which is derived from both the ZIndex and the containment structure. </summary>
        int CalculatedZIndex { get; }
        float CalculatedXInPixels { get; }
        float CalculatedYInPixels { get; }
        float CalculatedWidthInPixels { get; }
        float CalculatedHeightInPixels { get; }
        int CalculatedLayer { get; }
        bool CalculatedVisible { get; }
        bool CalculatedEnabled { get; }
    }
}
