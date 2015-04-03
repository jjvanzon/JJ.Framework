using JJ.Framework.Reflection.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Presentation.Drawing
{
    /// <summary>
    /// Allows you to draw graphics in a buffer,
    /// and only if you are done, draw the result to the target Graphics.
    /// This allows you to create smoothly drawn graphics with System.Drawing.
    /// </summary>
    public class GraphicsBuffer
    {
        /// <summary> The target graphics to which the buffer will eventually be drawn. </summary>
        private readonly Graphics _targetGraphics;

        /// <summary> Smoothing mode is reassigned every time we create a new buffer. </summary>
        private readonly SmoothingMode _smoothingMode;

        /// <summary> A wrapper that System.Drawing creates that we have to use to render to the target buffer. </summary>
        private BufferedGraphics _bufferedGraphics;

        /// <summary> 
        /// The previous width and height are remembed, 
        /// to see if we need to create a new buffer with a new size.
        /// </summary>
        private int _width;

        /// <summary>
        /// The previous width and height are remembed,
        /// to see if we need to create a new buffer with a new size.
        /// </summary>
        private int _height;

        /// <summary> Execute draw methods on this. </summary>
        public Graphics Graphics { get; private set; }

        public GraphicsBuffer(Graphics targetGraphics, SmoothingMode smoothingMode = SmoothingMode.AntiAlias)
        {
            if (targetGraphics == null) throw new NullException(() => targetGraphics);

            _targetGraphics = targetGraphics;
            _smoothingMode = smoothingMode;
        }

        /// <summary> Assigns Graphics object that works in a buffer. </summary>
        public void StartBuffering(int width, int height)
        {
            // Check if allocating a different buffer is necessary, because the dimensions changed
            if (width != _width || height != _height)
            {
                _width = width;
                _height = height;

                // I am not sure why I would have to be this tollerant.
                if (_width < 1) _width = 1;
                if (_height < 1) _height = 1;

                // Earlier I added 1 to the width and height. I am not sure why.
                Rectangle rectangle = new Rectangle(0, 0, _width, _height);

                BufferedGraphicsManager.Current.MaximumBuffer = rectangle.Size;
                _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(_targetGraphics, rectangle);
                _bufferedGraphics.Graphics.SmoothingMode = _smoothingMode;

                Graphics = _bufferedGraphics.Graphics;
            }
        }

        /// <summary> Displays buffered graphics onto the target graphics. </summary>
        public void DrawBuffer()
        {
            _bufferedGraphics.Render(_targetGraphics);
        }
    }
}
