using JJ.Framework.Presentation.Svg;
using JJ.Framework.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Presentation.Svg.LinkTo;
using System.Diagnostics;

namespace JJ.Framework.Presentation.Svg.Models.Elements
{
    /// <summary>
    /// A base class that can contain SVG child elements.
    /// </summary>
    public abstract class Element
    {
        internal Element()
        {
            Children = new ElementChildren(parent: this);
            Visible = true;
        }

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float X { get; set; }

        /// <summary>
        /// X-coordinate relative to the parent.
        /// </summary>
        public abstract float Y { get; set; }

        public bool Visible { get; set; }
        public int ZIndex { get; set; }

        private SvgModel _svgModel;
        public SvgModel SvgModel 
        {
            [DebuggerHidden]
            get { return _svgModel; }
            internal set
            {
                // TODO: Also remove relationship between parent and child.

                if (_svgModel == value) return;

                if (_svgModel != null)
                {
                    if (_svgModel.Elements.Contains(this))
                    {
                        _svgModel.Elements.Remove(this);
                    }
                }

                _svgModel = value;

                if (_svgModel != null)
                {
                    if (!_svgModel.Elements.Contains(this))
                    {
                        _svgModel.Elements.Add(this);
                    }
                }


                //this.LinkTo(_svgModel);

                //if (_svgModel != null) _svgModel.Elements.Remove(this);

                //_svgModel = value;

                //if (_svgModel != null) _svgModel.Elements.Add(this);
            }
        }

        private Element _parent;
        public Element Parent 
        {
            [DebuggerHidden]
            get { return _parent; }
            set 
            {
                if (_svgModel == null) throw new Exception("To assign a parent to a child, the child must be part of an SVG model.");

                if (_parent == value) return;

                if (_parent != null)
                {
                    if (_parent.Children.Contains(this))
                    {
                        _parent.Children.Remove(this);
                    }
                }

                _parent = value;

                if (_parent != null)
                {
                    if (!_parent.Children.Contains(this))
                    {
                        _parent.Children.Add(this);
                    }
                }

                // Side-Effect
                if (_parent == null)
                {
                    if (this != _svgModel.RootRectangle)
                    {
                        _svgModel.RootRectangle.Children.Add(this);
                    }
                }
            }
        }

        public ElementChildren Children { get; private set; }

        public bool EventBubblingEnabled { get; set; }

        /// <summary>
        /// The calculated ZIndex, which is derived from both
        /// the ZIndex and the containment structure.
        /// </summary>
        public int CalculatedZIndex { get; internal set; }

        /// <summary>
        /// In the flat clone solution this was internal.
        /// </summary>
        public int CalculatedLayer { get; internal set; }

        /// <summary>
        /// Calculated, absolute X coordinate.
        /// </summary>
        public float CalculatedX { get; internal set; }

        /// <summary>
        /// Calculated, absolute Y coordinate.
        /// </summary>
        public float CalculatedY { get; internal set; }
    }
}
