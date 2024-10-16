﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.WinForms.Helpers;

namespace JJ.Framework.WinForms.Extensions
{
    [PublicAPI]
    public static class ControlExtensions
    {
        /// <summary>
        /// Automatically assigns tab indexes to the specified control and all its child controls and their children.
        /// The procedure goes through the descendent tree recursively so that the tab index is based on the composition structure of the controls,
        /// and siblings are assigned tab indexes based on their (X, Y) coordinates.
        /// This may results in the most intuitive tab index. 
        /// If it does not, it might be something to consider, to grouping controls together using containers controls, such as a Panel control.
        /// </summary>
        /// <param name="control">Parent control</param>
        /// <param name="currentTabIndex">The tab index to start with (optional)</param>
        public static void AutomaticallyAssignTabIndexes(this Control control, int currentTabIndex = 1)
        {
            if (control == null) throw new NullException(() => control);

            control.TabIndex = currentTabIndex++;

            // ReSharper disable once SuggestVarOrType_Elsewhere
            var sortedChildren =
                from Control x in control.Controls
                orderby x.Location.Y, x.Location.X
                select x;

            foreach (Control child in sortedChildren)
            {
                AutomaticallyAssignTabIndexes(child, currentTabIndex++);
            }
        }

        public static IList<TControl> GetDescendantsOfType<TControl>(this Control control) => ControlHelper.GetDescendantsOfType<TControl>(control);

        public static UserControl GetAncestorUserControl(this Control control) => ControlHelper.GetAncestorUserControl(control);
    }
}
