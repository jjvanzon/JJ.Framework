using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary>
    /// Might be used to control the right / left / center placement
    /// of for instance text being drawn on screen.
    /// </summary>
    public enum HorizontalAlignmentEnum
    {
        /// <inheritdoc cref="DashStyleEnum.Undefined" />
        [UsedImplicitly] Undefined,
        /// <inheritdoc cref="HorizontalAlignmentEnum" />
        Left,
        /// <inheritdoc cref="HorizontalAlignmentEnum" />
        Center,
        /// <inheritdoc cref="HorizontalAlignmentEnum" />
        Right
    }
}