using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirtelSales.DAL;
using Microsoft.AspNet.Identity;

namespace AirtelSales.Controllers
{
    public class IncentiveController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();

        // GET: Incentive
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var mkt = db.sf_user_profiles.FirstOrDefault(m => m.PROFILE_ID == user.ProfileId);
            return View(mkt);
        }

        public ActionResult Dealer(string RegionCode)
        {
            if (RegionCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var mktDev = db.MarketDevelopers.Find(MktDevId).RegionalManager;
            //string code = Convert.ToString(mktDev.RegionId);
            var incentives = db.kpi_dealer_sales.Where(s => s.RegionCode == RegionCode).OrderByDescending(s => s.Id).ToList();
            return View(incentives);
        }

        public ActionResult Subdealer(string dealerCode)
        {
            if (dealerCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var incentives = db.kpi_subdealer_sales.Where(s => s.DealerCode == dealerCode).OrderByDescending(s => s.Id).ToList();
            return View(incentives);
        }

        public ActionResult Reseller(string subdealerCode)
        {
            if (subdealerCode == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var incentives = db.kpi_reseller_sales.Where(s => s.SubdealerCode == subdealerCode).OrderByDescending(s => s.Id).ToList();
            return View(incentives);
        }

    }
}
