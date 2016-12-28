using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
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

        [Inject]
        public ICompanyService CompanyService { get; set; }

        [PermissionFilter]
        public ActionResult Index()
        {
            var userDto = UserService.Get(Request.GetToken());
            return View(userDto);
        }

        [PermissionFilter]
        public ActionResult CompaniesList(string subString)
        {
            var companies = CompanyService.Find(subString);
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        [PermissionFilter]
        public ActionResult AddTicker(string companyId)
        {
            Guid companyGuid;
            if(Guid.TryParse(companyId, out companyGuid))
                UserService.AddTicker(Request.GetToken(), companyGuid);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [PermissionFilter]
        public ActionResult DeleteTicker(Guid companyId)
        {
            UserService.DeleteTicker(Request.GetToken(), companyId);

            return Json("Success", JsonRequestBehavior.AllowGet);
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