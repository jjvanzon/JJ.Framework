using JJ.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JJ.Framework.Collections;

namespace JJ.Framework.Presentation.WinForms.Helpers
{
    public static class ControlHelper
    {
        /// <summary>
        /// Alternative form Graphics.MeasureString, that uses FontScaling.
        /// LIMITATION: Only works if the control is placed inside a UserControl.
        /// </summary>
        public static SizeF MeasureStringWithFontScaling(Graphics graphics, Control control)
        {
            return MeasureStringWithFontScaling(graphics, control.Font, control.Text, control);
        }

        /// <summary>
        /// Alternative form Graphics.MeasureString that uses Font scaling (behavior similar to Form.AutoScaleMode = Font).
        /// LIMITATION: Only works if the control is placed inside a UserControl
        /// and only after the ParentForm has been assigned.
        /// (In some phases of the UserControl's loading and designer-generated code going off, ParentForm is not assigned yet.)
        /// </summary>
        public static SizeF MeasureStringWithFontScaling(Graphics graphics, Font font, string text, Control control)
        {
            if (graphics == null) throw new NullException(() => graphics);
            if (font == null) throw new NullException(() => font);
            if (control == null) throw new NullException(() => control);

            UserControl userControl = ControlHelper.GetAncestorUserControl(control);
            if (userControl.ParentForm == null) throw new NullException(() => userControl.ParentForm);

            SizeF size = graphics.MeasureString(text, font);

            // Use Font scaling.
            // UserControl.AutoScaleFactor.Width does not work,
            // not only because it is protected,
            // but because WinForms does not make AutoScaleFactor.Width > 1
            // when the font is changed in the form.

            float autoScaleFactor = userControl.Font.Size / userControl.ParentForm.Font.Size;
            bool autoScaleFactorIs1 = autoScaleFactor - 1 < 0.001; // Beware for rounding errors when equating floats.
            if (!autoScaleFactorIs1)
            {
                const float fontScalingCorrectionFactor = 0.9f; // Completely arbitrary experimentally obtained factor.
                autoScaleFactor *= fontScalingCorrectionFactor;
            }

            SizeF scaledSize = new SizeF(size.Width * autoScaleFactor, size.Height * autoScaleFactor);
            return scaledSize;
        }

        public static UserControl GetAncestorUserControl(Control control)
        {
            if (control == null) throw new NullException(() => control);

            Control ancestor = control.Parent;
            while (ancestor != null)
            {
                var ancestorUserControl = ancestor as UserControl;
                if (ancestorUserControl != null)
                {
                    return ancestorUserControl;
                }

                ancestor = ancestor.Parent;
            }

            throw new Exception(string.Format("No ancestor UserControl found for Control '{0}'.", control.Name));
        }

        public static IList<TControl> GetDescendantsOfType<TControl>(Control control)
        {
            if (control == null) throw new NullException(() => control);

            IList<TControl> descendants = control.Controls.Cast<Control>()
                                                          .SelectRecursive(x => x.Controls.Cast<Control>())
                                                          .OfType<TControl>()
                                                          .ToArray();
            return descendants;
        }
    }
}
