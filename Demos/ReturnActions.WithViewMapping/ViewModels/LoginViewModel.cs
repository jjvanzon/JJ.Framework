using JJ.Demos.ReturnActions.Framework.Presentation;

namespace JJ.Demos.ReturnActions.WithViewMapping.ViewModels
{
	public class LoginViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public ActionInfo ReturnAction { get; set; }
	}
}
