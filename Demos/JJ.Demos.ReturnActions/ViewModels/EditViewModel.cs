using JJ.Demos.ReturnActions.ViewModels.Entities;
using JJ.Framework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.ViewModels
{
    public sealed class EditViewModel
    {
        public EntityViewModel Entity { get; set; }

        /// <summary> nullable </summary>
        public ActionInfo ReturnAction { get; set; }
    }
}