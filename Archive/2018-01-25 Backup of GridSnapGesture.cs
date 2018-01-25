//using System;
//using JJ.Framework.Mathematics;
//using JJ.Framework.Presentation.VectorGraphics.Enums;
//using JJ.Framework.Presentation.VectorGraphics.EventArg;

//namespace JJ.Framework.Presentation.VectorGraphics.Gestures
//{
//	/// <summary>
//	/// A simple grid snap implementation. When a move gesture is associated with a grid snap gesture,
//	/// the coordinates snap to grid upon moving. It doesn't show a grid nor makes it optional to snap with like a Ctrl key or something.
//	/// </summary>
//	public class GridSnapGesture : GestureBase
//	{
//		private readonly MoveGesture _moveGesture;
//		private readonly float _snapX;
//		private readonly float _snapY;
//		private readonly float _offsetX;
//		private readonly float _offsetY;

//		public GridSnapGesture(MoveGesture moveGesture, float step, GridSnapEnum gridSnapEnum = GridSnapEnum.WhileMoving)
//			: this(moveGesture, step, step, gridSnapEnum) { }

//		public GridSnapGesture(MoveGesture moveGesture, float snapX, float snapY, GridSnapEnum gridSnapEnum = GridSnapEnum.WhileMoving)
//			: this(moveGesture, snapX, snapY, 0, 0, gridSnapEnum) { }

//		public GridSnapGesture(
//			MoveGesture moveGesture,
//			float snapX,
//			float snapY,
//			float offsetX,
//			float offsetY,
//			GridSnapEnum gridSnapEnum = GridSnapEnum.WhileMoving)
//		{
//			_moveGesture = moveGesture ?? throw new ArgumentNullException(nameof(moveGesture));

//			_snapX = snapX;
//			_snapY = snapY;
//			_offsetX = offsetX;
//			_offsetY = offsetY;

//			switch (gridSnapEnum)
//			{
//				case GridSnapEnum.WhileMoving:
//					_moveGesture.Moving += _moveGesture_Moving;
//					break;

//				case GridSnapEnum.AfterMoved:
//					_moveGesture.Moved += _moveGesture_Moved;
//					break;
//			}
//		}

//		~GridSnapGesture()
//		{
//			if (_moveGesture != null)
//			{
//				_moveGesture.Moved -= _moveGesture_Moved;
//				_moveGesture.Moving -= _moveGesture_Moving;
//			}
//		}

//		private void _moveGesture_Moving(object sender, ElementEventArgs e) => DoGridSnap(e);
//		private void _moveGesture_Moved(object sender, ElementEventArgs e) => DoGridSnap(e);

//		private void DoGridSnap(ElementEventArgs e)
//		{
//			e.Element.Position.X = MathHelper.RoundWithStep(e.Element.Position.X, _snapX, _offsetX);
//			e.Element.Position.Y = MathHelper.RoundWithStep(e.Element.Position.Y, _snapY, _offsetY);
//		}
//	}
//}