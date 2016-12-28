using System.Web.Mvc;
using Stock.Client.Web.StockWebServiceReference;
using Stock.Client.Web.Tools;
using Stock.Client.Web.ViewModels;

namespace Stock.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        [PermissionFilter]
        public ActionResult Index()
        {
            return View();
        }

        [PermissionFilter]
        public ActionResult TestWebService()
        {
            ViewBag.Message = "Your application description page.";

            var client = new StockWebServiceSoapClient();
            var result = client.GetStockPrice("AAA,GOOG");
            client.Close();

            var model = new AboutViewModel
            {
                Result = result
            };

            return View(model);
        }
    }
}