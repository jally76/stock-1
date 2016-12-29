using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Web.Services3.Security.Tokens;
using Newtonsoft.Json;
using Ninject;
using Stock.Client.Web.ServiceReference1;
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
            return View();
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
        public ActionResult GetUserTicker()
        {
            var userDto = UserService.Get(Request.GetToken());

            var client = new StockWebServiceSoapClient();
            var result = client.GetStockPrice(string.Join(",", userDto.Tickers.Select(t => t.Code)));
            client.Close();

            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(result);

            foreach (var ticker in userDto.Tickers)
            {
                ticker.Price = dictionary[ticker.Code];
            }

            return PartialView("UserPartialView", userDto);
        }
    }
}