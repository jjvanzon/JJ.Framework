﻿using System.Web.Optimization;

namespace JJ.Demos.ReturnActions.MvcPostDataViewMappings
{
	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
		}
	}
}