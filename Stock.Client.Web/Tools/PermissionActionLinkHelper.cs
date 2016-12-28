using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Stock.Client.Web.Tools
{
    public static class PermissionActionLinkHelper
    {
        public static MvcHtmlString PermissionActionLink(this HtmlHelper htmlHelper, string text, string actionName, string controllerName)
        {
            return InternalPermissionActionLink(htmlHelper, text, actionName, controllerName, null, null);
        }

        public static MvcHtmlString PermissionActionLink(this HtmlHelper htmlHelper, string text, string actionName, string controllerName, object routeValues, IDictionary<string, object> htmlAttributes)
        {
            return InternalPermissionActionLink(htmlHelper, text, actionName, controllerName, routeValues, htmlAttributes);
        }

        private static MvcHtmlString InternalPermissionActionLink(this HtmlHelper htmlHelper, string text, string actionName, string controllerName, object routeValues, IDictionary<string, object> htmlAttributes)
        {
            if (htmlHelper.ViewContext.HttpContext.Request.IsAuthorized())
                return htmlHelper.ActionLink(text, actionName, controllerName, routeValues, htmlAttributes);

            return MvcHtmlString.Empty;
        }
    }

}
