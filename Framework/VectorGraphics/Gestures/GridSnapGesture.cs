using System;
using JJ.Framework.Mathematics;
using JJ.Framework.VectorGraphics.Enums;
using JJ.Framework.VectorGraphics.EventArg;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace JJ.Framework.VectorGraphics.Gestures
{
	/// <summary>
	/// A simple grid snap implementation. When a move gesture is associated with a grid snap gesture,
	/// the coordinates snap to grid upon moving. It doesn't show a grid nor makes it optional to snap with like a Ctrl key or something.
	/// </summary>
	public class GridSnapGesture : GestureBase
	{
		private const float DEFAULT_SNAP = 8f;

		private readonly MoveGesture _moveGesture;

		public GridSnapGesture(MoveGesture moveGesture)
		{
			_moveGesture = moveGesture ?? throw new ArgumentNullException(nameof(moveGesture));
			_moveGesture.Moving += _moveGesture_Moving;
			_moveGesture.Moved += _moveGesture_Moved;
		}

		~GridSnapGesture()
		{
			if (_moveGesture != null)
			{
				_moveGesture.Moved -= _moveGesture_Moved;
				_moveGesture.Moving -= _moveGesture_Moving;
			}
		}

		public float SnapX { get; set; } = DEFAULT_SNAP;
		public float SnapY { get; set; } = DEFAULT_SNAP;
		public float OffsetX { get; set; }
		public float OffsetY { get; set; }
		public GridSnapModeEnum GridSnapModeEnum { get; set; } = GridSnapModeEnum.WhileMoving;

		public float? Snap
		{
			get
			{
				if (SnapX == SnapY) return SnapX;
				return null;
			}
			set
			{
				if (!value.HasValue)
				{
					SnapX = default;
					SnapY = default;
					return;
				}

				SnapX = value.Value;
				SnapY = value.Value;
			}
		}

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
			e.Element.Position.X = MathHelper.RoundWithStep(e.Element.Position.X, SnapX, OffsetX);
			e.Element.Position.Y = MathHelper.RoundWithStep(e.Element.Position.Y, SnapY, OffsetY);
		}
	}
}