using System;
using System.Web;

namespace Stock.Client.Web.Tools
{
    public static class HttpExtension
    {
        public static bool IsAuthorized(this HttpRequestBase request)
        {
            return !string.IsNullOrEmpty(GetToken(request));
        }

        public static string GetToken(this HttpRequestBase request)
        {
            return request.Cookies["token"]?.Value;
        }

        public static void SetAuth(this HttpResponseBase response, string email)
        {
            var authCookie = new HttpCookie("token") { Value = email, Expires = DateTime.Now.AddDays(30) };
            response.Cookies.Set(authCookie);
        }
    }
}
