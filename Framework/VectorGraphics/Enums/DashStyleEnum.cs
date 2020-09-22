using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary> Aims to describe the type of dash style to draw lines with for instance. </summary>
    public enum DashStyleEnum
    {
        /// <summary>
        /// Exists to try and uphold a pattern, where not assigning a value, there may be a chance
        /// that you might get a descriptive exception message instead of an unexpected default.
        /// </summary>
        [UsedImplicitly] Undefined,
        /// <summary> Indicates a line might be drawn as a solid line, so no dashes or dots. </summary>
        Solid,
        /// <summary> Indicates a line might be drawn with dashed style. </summary>
        Dashed,
        /// <summary> Indicates a line might be drawn with a dotted style. </summary>
        Dotted
    }
}