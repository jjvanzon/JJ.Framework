using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary> Might be used to control the top / left / bottom placement of for instance text being drawn on screen. </summary>
    public enum VerticalAlignmentEnum
    {
        /// <inheritdoc cref="DashStyleEnum.Undefined" />
        [UsedImplicitly] Undefined,
        /// <inheritdoc cref="VerticalAlignmentEnum" />
        Top,
        /// <inheritdoc cref="VerticalAlignmentEnum" />
        Center,
        /// <inheritdoc cref="VerticalAlignmentEnum" />
        Bottom
    }
}