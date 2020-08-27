using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary>
    /// Used for the GridSnapGesture, which makes moving an element over the screen
    /// result in a position on an invisible raster point, instead of an arbitrary position.
    /// </summary>
    public enum GridSnapModeEnum
    {
        /// <inheritdoc cref="DashStyleEnum.Undefined" />
        [UsedImplicitly] Undefined,
        /// <summary>
        /// Indicates that an element's position might snap to a grid position
        /// while dragging, not only after the lifting the finger.
        /// </summary>
        WhileMoving,
        /// <summary>
        /// Indicates that an element's position might snap to a grid position
        /// not while moving, but after lifting the finger.
        /// </summary>
        AfterMoved
    }
}