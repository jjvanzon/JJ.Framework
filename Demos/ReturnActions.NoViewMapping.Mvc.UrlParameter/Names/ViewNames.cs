using JJ.Demos.ReturnActions.Mvc.Names;
using JJ.Framework.Exceptions;

namespace JJ.Demos.ReturnActions.NoViewMapping.Mvc.UrlParameter.Names
{
    public abstract class ViewNames : ViewNamesBase
    {
        public void Error() => throw new NameOfOnlyException();
        public void NotAuthorized() => throw new NameOfOnlyException();
    }
}