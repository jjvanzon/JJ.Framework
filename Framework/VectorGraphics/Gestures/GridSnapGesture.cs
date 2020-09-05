using System;
using JetBrains.Annotations;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.EventArg;

// ReSharper disable InvertIf

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// A relatively simple grid snap implementation.
	/// When a move gesture would be associated with a grid snap gesture,
	/// the coordinates of an element may snap to grid.
	/// It would not show a grid nor make it optional to snap with like a Ctrl key or something.
	/// NOTE: This may not be a gesture that might be tied to an element.
	/// A MoveGesture may be passed to the constructor instead.
	/// It might not derive from GestureBase either.
	/// </summary>
	public class GridSnapGesture
	{
		private const float DEFAULT_SNAP = 8f;

		private readonly MoveGesture _moveGesture;

		/// <inheritdoc cref="GridSnapGesture" />
		public GridSnapGesture(MoveGesture moveGesture)
		{
			_moveGesture = moveGesture ?? throw new ArgumentNullException(nameof(moveGesture));
			_moveGesture.Moving += _moveGesture_Moving;
			_moveGesture.Moved += _moveGesture_Moved;
		}

		/// <summary> Aims to clean up events that would be tied to the associated move gesture. </summary>
		~GridSnapGesture()
		{
			if (_moveGesture != null)
			{
				_moveGesture.Moved -= _moveGesture_Moved;
				_moveGesture.Moving -= _moveGesture_Moving;
			}
		}

		/// <summary> Would be the width or height between grid points. Default = 8. </summary>
		[PublicAPI]
		public float SnapWidth { get; set; } = DEFAULT_SNAP;

		/// <inheritdoc cref="SnapWidth" />
		[PublicAPI]
		public float SnapHeight { get; set; } = DEFAULT_SNAP;

		/// <summary>
		/// In case the grid would not start at point (0, 0) you might shift it using these Offset properties.
		/// </summary>
		[PublicAPI]
		public float OffsetX { get; set; }

		/// <inheritdoc cref="OffsetX" />
		[PublicAPI]
		public float OffsetY { get; set; }

		/// <summary>
		/// Would indicate that an element's position might snap to a grid position
		/// while dragging, or after the lifting a finger. Default = WhileMoving.
		/// </summary>
		[PublicAPI]
		public GridSnapModeEnum GridSnapModeEnum { get; set; } = GridSnapModeEnum.WhileMoving;

		/// <inheritdoc cref="SnapWidth" />
		public float? Snap
		{
			[PublicAPI]
			get
			{
				if (SnapWidth == SnapHeight) return SnapWidth;
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					SnapWidth = default;
					SnapHeight = default;
					return;
				}

				SnapWidth = value.Value;
				SnapHeight = value.Value;
			}
		}

		/// <inheritdoc cref="OffsetX" />
		[PublicAPI]
		public float? Offset
		{
			get
			{
				if (OffsetX == OffsetY) return OffsetX;
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					OffsetX = default;
					OffsetY = default;
					return;
				}

				OffsetX = value.Value;
				OffsetY = value.Value;
			}
		}

		private void _moveGesture_Moving(object sender, ElementEventArgs e)
		{
			if (GridSnapModeEnum != GridSnapModeEnum.WhileMoving)
			{
				return;
			}

			DoGridSnap(e);
		}

		private void _moveGesture_Moved(object sender, ElementEventArgs e)
		{
			if (GridSnapModeEnum != GridSnapModeEnum.AfterMoved)
			{
				return;
			}

			DoGridSnap(e);
		}

		private void DoGridSnap(ElementEventArgs e)
		{
			e.Element.Position.X = MathHelper.RoundWithStep(e.Element.Position.X, SnapWidth, OffsetX);
			e.Element.Position.Y = MathHelper.RoundWithStep(e.Element.Position.Y, SnapHeight, OffsetY);
		}
	}
}