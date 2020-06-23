using AirtelSales.DAL;
using AirtelSales.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirtelSales.Controllers
{
    public class DashboardController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        ApplicationDbContext context = new ApplicationDbContext();


        // GET: Dashboard
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);

            if (UserManager.IsInRole(userId, "RegionalManager"))
            {
                var regionalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                var regionalManagerKPI = db.kpi_region_sales.Where(m => m.RegionCode == regionalManager.region_code.ToString()).OrderByDescending(m => m.Id).FirstOrDefault();
                var allZonalManagerKPI = db.kpi_zone_sales.Where(m => m.RegionCode == regionalManager.region_code.ToString()).Take(3);
                ViewBag.AllZonalManagerKPI = allZonalManagerKPI;
                ViewBag.Region = regionalManager.region_code;
                ViewBag.RegionalManagerKPI = regionalManagerKPI;
            }
            else if (UserManager.IsInRole(userId, "ZonalManager"))
            {
                var zonalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                
                var zonalManagerKPI = db.kpi_zone_sales.Where(m => m.ZoneName == zonalManager.zonal_code).OrderByDescending(m => m.Id).FirstOrDefault();
                var allAreaManagerKPI = db.kpi_area_sales.Where(m => m.ZoneCode == zonalManager.zonal_code).Take(3);
                ViewBag.AllAreaManagerKPI = allAreaManagerKPI;
                ViewBag.ZonalManagerKPI = zonalManagerKPI;
            }
            else if (UserManager.IsInRole(userId, "AreaManager"))
            {
                var areaManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                var areaManagerKPI = db.kpi_area_sales.Where(m => m.AreaCode == areaManager.area_code).OrderByDescending(m => m.Id).FirstOrDefault();
                var allMarketDeveloperKPI = db.kpi_mktdev_sales.Where(m => m.AreaCode == areaManager.area_code).Take(3);
                ViewBag.AllMarketDeveloperKPI = allMarketDeveloperKPI;
                ViewBag.AreaManagerKPI = areaManagerKPI;
            }
            else if (UserManager.IsInRole(userId, "MarketDeveloper"))
            {
                var marketDeveloper = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                var marketDeveloperKPI = db.kpi_mktdev_sales.Where(m => m.MarketDevCode == marketDeveloper.marketdev_code).OrderByDescending(m => m.Id).FirstOrDefault();
                var allDealerKPI = db.kpi_dealer_sales.Where(m => m.RegionCode == "1").Take(3);
                ViewBag.MarketDeveloperKPI = marketDeveloperKPI;
                ViewBag.AllDealerKPI = allDealerKPI;
            }

            return View();
        }

        //public ActionResult RegionalManagerData()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var regionId = db.RegionalManagers.Where(u => u.UserId == userId).FirstOrDefault().RegionId;
        //    var RMData = db.RegionalManagerKPIs.Where(rm => rm.RegionCode == regionId.ToString() && rm.Month.Value.Month <= DateTime.Now.Month  ).ToList().OrderBy(rm=> rm.Month);

        //    return Json(RMData, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult RegionalManagerKPI()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var regionalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
            var regionalManagerKPI = db.kpi_region_sales.Where(m => m.RegionCode == regionalManager.region_code).Take(6);
            List<RMZonalManagersData> data = new List<RMZonalManagersData>();

            return Json(regionalManagerKPI, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ZonalManagerKPI()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var zonalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
            var zonalManagerKPI = db.kpi_zone_sales.Where(m => m.ZoneCode == zonalManager.zonal_code).Take(6);
            return Json(zonalManagerKPI, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AreaManagerKPI()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var areaManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
            var areaManagerKPI = db.kpi_area_sales.Where(m => m.AreaCode == areaManager.area_code).Take(6);
            return Json(areaManagerKPI, JsonRequestBehavior.AllowGet);
        }

        public ActionResult marketDeveloperKPI()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var marketDeveloper = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
            var marKetDeveloperKPI = db.kpi_mktdev_sales.Where(m => m.MarketDevCode == marketDeveloper.marketdev_code).Take(6);
            return Json(marKetDeveloperKPI, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult MarketDeveloperData()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var marketId = db.MarketDevelopers.Where(u => u.UserId == userId).FirstOrDefault().MarketId;
        //    var marketCode = db.Markets.Find(marketId).Code;
        //    var MDData = db.MarketDeveloperKPIs.Where(rm => rm.MarketDeveloperCode == marketCode && rm.Month.Value.Month <= DateTime.Now.Month).ToList().OrderBy(rm => rm.Month);

        //    return Json(MDData, JsonRequestBehavior.AllowGet);
        //}
    }
}