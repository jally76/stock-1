using System.Web.Mvc;

namespace Stock.Client.Web.Tools
{
    public class PermissionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request.IsAuthorized())
                return;

            filterContext.Result = new RedirectResult("~/Auth/Logon");
        }
    }
}
