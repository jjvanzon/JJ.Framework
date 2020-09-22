using JetBrains.Annotations;

namespace JJ.Framework.VectorGraphics.Enums
{
    /// <summary>
    /// Used for the GridSnapGesture, which makes moving an element over the screen
    /// result in a position on an invisible raster point, instead of an arbitrary position.
    /// See the members for more details.
    /// </summary>
    public enum GridSnapModeEnum
    {
        /// <inheritdoc cref="DashStyleEnum.Undefined" />
        [UsedImplicitly] Undefined,
        /// <summary>
        /// Would indicate that an element's position might snap to a grid position
        /// while dragging, not only after the lifting a finger.
        /// </summary>
        WhileMoving,
        /// <summary>
        /// Would Indicate that an element's position might snap to a grid position
        /// not while moving, but after lifting a finger.
        /// </summary>
        AfterMoved
    }
}