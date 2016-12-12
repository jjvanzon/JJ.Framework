using JJ.Framework.Exceptions;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using JJ.Framework.Presentation.WinForms.Helpers;

namespace JJ.Framework.Presentation.WinForms.Extensions
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Automatically assigns tab indexes to the specified control and all its child controls and their children.
        /// The procedure goes through the descendent tree recursively so that the tab index is based on the composition structure of the controls,
        /// and sibblings are assigned tab indexes based on their (X, Y) coordinates.
        /// This results in the most intuitive tab index. 
        /// If it does not, consider grouping controls together using containers controls, such as a Panel control.
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="currentTabIndex">The tab index to start with (optional)</param>
        public static void AutomaticallyAssignTabIndexes(this Control control, int currentTabIndex = 1)
        {
            if (control == null) throw new NullException(() => control);

            control.TabIndex = currentTabIndex++;

            var sortedChildren =
                from Control x in control.Controls
                orderby x.Location.Y, x.Location.X
                select x;

            foreach (Control child in sortedChildren)
            {
                AutomaticallyAssignTabIndexes(child, currentTabIndex++);
            }
        }

        public static IList<TControl> GetDescendantsOfType<TControl>(this Control control)
        {
            return ControlHelper.GetDescendantsOfType<TControl>(control);
        }

        public static UserControl GetAncestorUserControl(this Control control)
        {
            return ControlHelper.GetAncestorUserControl(control);
        }
    }
}
