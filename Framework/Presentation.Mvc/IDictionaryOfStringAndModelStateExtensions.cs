using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JJ.Framework.Mvc
{
	public static class IDictionaryOfStringAndModelStateExtensions
	{
		public static void ClearModelErrors(this IDictionary<string, ModelState> modelStateDictionary)
		{
			IList<KeyValuePair<string, ModelState>> entriesToRemove = modelStateDictionary.Where(x => x.Value.Errors.Count > 0).ToArray();
			foreach (KeyValuePair<string, ModelState> entryToRemove in entriesToRemove)
			{
				// TODO: Should I just remove the error, or the whole entry like this?
				modelStateDictionary.Remove(entryToRemove);
			}
		}
	}
}
