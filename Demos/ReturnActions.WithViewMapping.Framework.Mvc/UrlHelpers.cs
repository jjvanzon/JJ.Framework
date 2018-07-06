using System;
using System.Linq;
using System.Reflection;
using JJ.Demos.ReturnActions.Framework.Presentation;
using JJ.Framework.Presentation;
using JJ.Framework.Reflection;

namespace JJ.Demos.ReturnActions.Framework.Mvc
{
    // TODO: Make internal after making the Accessor class able to access internal classes,
    // so internal classes can be used in unit tests.

    /// <summary>
    /// Plural to not conflict with 'UrlHelper'.
    /// </summary>
    public static class UrlHelpers
    {
        private static readonly ReflectionCache _reflectionCache = new ReflectionCache(BindingFlags.Public | BindingFlags.Instance);

        /// <summary>
        /// Converts presenter action info to an MVC URL.
        /// Stacks up return URL parameters as follows:
        /// Questions/Details?id=1
        /// Questions/Edit?id=1&amp;ret=Questions%2FDetails%3Fid%3D1
        /// Login/Index&amp;ret=Questions%2FEdit%3Fid%3D1%26ret%3DQuestions%252FDetails%253Fid%253D1
        /// Returns null if actionInfo is null.
        /// </summary>
        public static string ReturnAction(ActionInfo presenterActionInfo, string returnUrlParameterName = "ret")
        {
            if (presenterActionInfo == null)
            {
                return null;
            }

            return ActionDispatcher.GetUrl(presenterActionInfo, returnUrlParameterName);
        }

        /// <summary>
        /// The difference with Url.Action is that Url.ReturnAction will produce
        /// a URL that does not fallback to default actions,
        /// nor uses parameters as URL path parts,
        /// but instead returns then as regular URL parameters.
        /// That kind of URL is better interpretable by the Presentation framework,
        /// that needs to convert it to presenter information.
        /// </summary>
        public static string ReturnAction(string actionName, string controllerName, object routeValues = null)
        {
            var actionInfo = new ActionInfo
            {
                PresenterName = controllerName,
                ActionName = actionName
            };

            if (routeValues == null)
            {
                actionInfo.Parameters = new ActionParameterInfo[0];
            }
            else
            {
                actionInfo.Parameters = _reflectionCache.GetProperties(routeValues.GetType())
                                                        .Select(
                                                            x => new ActionParameterInfo
                                                            {
                                                                Name = x.Name,
                                                                Value = Convert.ToString(x.GetValue(routeValues, null))
                                                            })
                                                        .ToArray();
            }

            string returnUrl =
                ActionInfoToUrlConverter.ConvertActionInfoToUrl(
                    actionInfo,
                    returnUrlParameterName: "ret"); // returnUrlParameterName does not matter here.
            return returnUrl;
        }
    }
}