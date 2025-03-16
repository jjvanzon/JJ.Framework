using JJ.Demos.ReturnActions.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJ.Demos.ReturnActions.ViewModels
{
    public sealed class ListViewModel
    {
        public IList<EntityViewModel> List { get; set; }
    }
}