using System.Collections.Generic;
using System.Linq;
// ReSharper disable InconsistentNaming
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JJ.Framework.Mvc
{
    public static class IDictionaryOfStringAndModelStateExtensions
    {
        public static void ClearModelErrors(this ModelStateDictionary modelState)
        {
            var entriesToClear = modelState.Where(x => x.Value.Errors.Count > 0).ToArray();
            foreach (var entryToRemove in entriesToClear)
            {
                // TODO: This was a guess migrating from .NET 4.6.1 to .NET 7.
                modelState.SetModelValue(entryToRemove.Key, ValueProviderResult.None);
            }
        }
    }
}
