using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.Exceptions;
using JJ.Framework.VectorGraphics.Models.Styling;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	/// <summary>
	/// Represents a curved line going from one point to the next,
	/// going into the direction of two other control points.
	/// </summary>
	public class Curve : Element
	{
		public Curve()
		{
			Position = new CurvePosition(this);
		}

		private int _segmentCount = 20;

		/// <summary>
		/// Default is 20. Cannot be less than 1.
		/// The curve is drawn out as a sequence of straight lines.
		/// The segment count controls the precision with which the curve is drawn.
		/// </summary>
		public int SegmentCount 
		{
			[DebuggerHidden]
			get { return _segmentCount; }
			set
			{
				if (value < 1) throw new LessThanException(() => value, 1);
				_segmentCount = value;
			}
		}

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point PointA { get; set; }

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point PointB { get; set; }

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point ControlPointA { get; set; }

		/// <summary> Nullable. Coordinates of the point are related to the Point's parent. </summary>
		public Point ControlPointB { get; set; }

		private LineStyle _lineStyle = new LineStyle();
		/// <summary> not nullable, auto-instantiated </summary>
		public LineStyle LineStyle
		{
			[DebuggerHidden]
			get { return _lineStyle; }
			set
			{
				_lineStyle = value ?? throw new NullException(() => value);
			}
		}

		public override ElementPosition Position { get; }

		private IList<Line> _calculatedLines = new List<Line>();
		/// <summary>
		/// Not nullable. Auto-instantiated.
		/// </summary>
		public IList<Line> CalculatedLines
		{
			[DebuggerHidden]
			get { return _calculatedLines; }
			internal set
			{
				_calculatedLines = value ?? throw new NullException(() => value);
			}
		}
	}
}
