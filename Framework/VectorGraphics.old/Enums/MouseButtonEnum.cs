using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary> An indication of which mouse button was pressed during a mouse gesture: left, right or none. </summary>
    public enum MouseButtonEnum
    {
        /// <inheritdoc cref="DashStyleEnum.Undefined" />
        [UsedImplicitly] Undefined,
        /// <inheritdoc cref="MouseButtonEnum" />
        Left,
        /// <inheritdoc cref="MouseButtonEnum" />
        Right,
        /// <inheritdoc cref="MouseButtonEnum" />
        None
    }
}