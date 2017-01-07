using System;

namespace JJ.Framework.Presentation.Mvc
{
    public class ViewMappingNotFoundException : Exception
    {
        private const string MESSAGE =
            "No mapping found for '{0}'. " +
            "Program an implementation of ViewMapping<TViewModel> to map view model types to their controllers, " +
            "actions, views and presenters. " +
            "Then call ActionDispatcher.RegisterAssembly passing along the assembly that contains your ViewMapping implementations. " +
            "Only call RegisterAssembly upon program initialization, because it is not thread-safe.";

        public ViewMappingNotFoundException(string viewMappingKeyDescription)
            : base(String.Format(MESSAGE, viewMappingKeyDescription))
        { }
    }
}