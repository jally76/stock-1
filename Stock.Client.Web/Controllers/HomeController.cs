using System.Web.Mvc;
using Stock.Client.Web.StockWebServiceReference;
using Stock.Client.Web.ViewModels;
using Stock.Core.Dto;

namespace Stock.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}