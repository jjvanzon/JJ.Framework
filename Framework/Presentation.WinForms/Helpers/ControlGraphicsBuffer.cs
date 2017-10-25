using JJ.Framework.Exceptions;
using JJ.Framework.Presentation.Drawing;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JJ.Framework.Presentation.WinForms.Helpers
{
    /// <summary>
    /// Allows you to draw graphics in a buffer,
    /// and only if you are done, draw the result to the target Control.
    /// This allows you to create smoothly drawn graphics in WinForms.
    /// The buffering starts as soon as you create the object.
    /// Use the draw methods of Graphics
    /// and when you are done call DrawBuffer to display the result in the control.
    /// </summary>
    public class ControlGraphicsBuffer : IDisposable
    {
        private readonly Control _control;
        private readonly Graphics _controlGraphics;
        private readonly GraphicsBuffer _graphicsBuffer;

        public ControlGraphicsBuffer(Control control, SmoothingMode smoothingMode = SmoothingMode.AntiAlias)
        {
            _control = control ?? throw new NullException(() => control);
            _control.SizeChanged += _control_SizeChanged;
            _controlGraphics = _control.CreateGraphics();

            _graphicsBuffer = new GraphicsBuffer(_controlGraphics, smoothingMode);
            _graphicsBuffer.StartBuffering(_control.Width, _control.Height);
        }

        ~ControlGraphicsBuffer()
        {
            Dispose();
        }

        public void Dispose()
        {
            _controlGraphics.Dispose();

            _control.SizeChanged -= _control_SizeChanged;

            GC.SuppressFinalize(this);
        }

        /// <summary> Execute draw methods on this. </summary>
        public Graphics Graphics => _graphicsBuffer.Graphics;

        /// <summary> Displays buffered graphics onto the control. </summary>
        public void DrawBuffer()
        {
            _graphicsBuffer.DrawBuffer();
        }

        private void _control_SizeChanged(object sender, EventArgs e)
        {
            _graphicsBuffer.StartBuffering(_control.Width, _control.Height);
        }
    }
}
