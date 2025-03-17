using JJ.Framework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Demos.ReturnActions.ViewModels
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public ActionInfo ReturnAction { get; set; }
    }
}
