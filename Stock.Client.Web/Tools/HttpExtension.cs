using System;
using System.Web;

namespace Stock.Client.Web.Tools
{
    public static class HttpExtension
    {
        public static bool IsAuthorized(this HttpRequestBase request)
        {
            return string.IsNullOrEmpty(request.Cookies["auth"]?.Value);
        }

        public static void SetAuth(this HttpResponseBase response, string email)
        {
            var authCookie = new HttpCookie("auth") { Value = email, Expires = DateTime.Now.AddDays(30) };
            response.Cookies.Set(authCookie);
        }
    }
}
