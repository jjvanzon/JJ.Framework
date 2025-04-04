﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;

namespace JJ.Framework.Presentation.Mvc
{
    public static class IDictionaryOfStringAndModelStateExtensions
    {
        public static void ClearModelErrors(this IDictionary<string, ModelState> modelStateDictionary)
        {
            IList<KeyValuePair<string, ModelState>> entriesToRemove = modelStateDictionary.Where(x => x.Value.Errors.Count > 0).ToArray();
            foreach (KeyValuePair<string, ModelState> entryToRemove in entriesToRemove)
            {
                modelStateDictionary.Remove(entryToRemove);
            }
        }
    }
}
