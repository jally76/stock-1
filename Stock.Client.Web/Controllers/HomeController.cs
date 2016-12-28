using System.Web.Mvc;
using Ninject;
using Stock.Client.Web.StockWebServiceReference;
using Stock.Client.Web.Tools;
using Stock.Client.Web.ViewModels;
using Stock.Core.Services;

namespace Stock.Client.Web.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IUserService UserService { get; set; }

        [PermissionFilter]
        public ActionResult Index()
        {
            var userDto = UserService.Get(Request.GetToken());
            return View(userDto);
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