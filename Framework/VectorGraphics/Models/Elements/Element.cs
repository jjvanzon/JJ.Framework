using System;
using System.Collections.Generic;
using System.Diagnostics;
using JJ.Framework.VectorGraphics.Gestures;
using JJ.Framework.VectorGraphics.Helpers;
using JJ.Framework.VectorGraphics.Relationships;
using JJ.Framework.VectorGraphics.SideEffects;

namespace JJ.Framework.VectorGraphics.Models.Elements
{
	/// <summary> base class that can contain VectorGraphics child elements. </summary>
	[DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
	public abstract class Element : IDisposable
	{
		/// <summary> The only element that needs no parent is the Diagram.Background element. </summary>
		internal Element(Diagram diagram)
		{
			_diagramRelationship = new ElementToDiagramRelationship(this);
			_parentRelationship = new ChildToParentRelationship(this);
			Children = new ElementChildren(this);

			_diagramRelationship.Parent = diagram ?? throw new ArgumentNullException(nameof(diagram));

			Visible = true;
			MustBubble = true;
			Enabled = true;
		}

		/// <param name="parent">When in doubt, use Diagram.Background.</param>
		public Element(Element parent)
			: this(parent?.Diagram) => _parentRelationship.Parent = parent ?? throw new ArgumentNullException(nameof(parent));

		public virtual void Dispose()
		{
			int childrenCount = Children.Count;
			for (int i = childrenCount - 1; i >= 0; i--)
			{
				Children[i].Dispose();
			}

			_parentRelationship.Parent = null;
			_diagramRelationship.Parent = null;
		}

		public bool Visible { get; set; }
		public int ZIndex { get; set; }
		public object Tag { get; set; }

		/// <summary>
		/// Typically assign as follows in the constructor of your derived class:
		/// Position = new RectanglePosition(this);
		/// </summary>
		public abstract ElementPosition Position { get; }

		public CalculatedValues CalculatedValues { get; } = new CalculatedValues();

		private IList<GestureBase> _gestures = new List<GestureBase>();
		/// <summary> not nullable </summary>
		public IList<GestureBase> Gestures
		{
			get => _gestures;
			set => _gestures = value ?? throw new ArgumentNullException(nameof(Gestures));
		}

		public bool MustBubble { get; set; }

		/// <summary> Indicates whether the element will respond to mouse and keyboard gestures. </summary>
		public bool Enabled { get; set; }

		private readonly ElementToDiagramRelationship _diagramRelationship;

		public Diagram Diagram
		{
			get => _diagramRelationship.Parent;
			internal set => _diagramRelationship.Parent = value ?? throw new ArgumentNullException(nameof(Diagram));
		}

		internal void NullifyDiagram() => _diagramRelationship.Parent = null;

		private readonly ChildToParentRelationship _parentRelationship;

		public Element Parent
		{
			get => _parentRelationship.Parent;
			set
			{
				if (value == null) throw new ArgumentNullException(nameof(Parent));

				if (value == _parentRelationship.Parent) return;

				new SideEffect_PreventCircularity(this, value).Execute();
				new SideEffect_AssertParentAndChildDiagramsAreEqual(this, value).Execute();

				_parentRelationship.Parent = value;
			}
		}

		internal void NullifyParent()
		{
			_parentRelationship.Parent = null;
		}

		public ElementChildren Children { get; }

		private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
	}
}