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
    public class DataController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Data
        public ActionResult Index()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);

            if (UserManager.IsInRole(userId, "ZonalManager"))
            {
                var zonalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                int zoneId = Convert.ToInt32(zonalManager.zonal_code.Substring(zonalManager.zonal_code.Length - 1));
                List<all_survey_responses> surveys = db.all_survey_responses.Where(r => r.state_id == zoneId ).ToList();
                return View(surveys);
            }

            else if (UserManager.IsInRole(userId, "AreaManager"))
            {
                var areaManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                int areaId = Convert.ToInt32(areaManager.area_code.Substring(areaManager.area_code.Length - 1));
                List<all_survey_responses> surveys = db.all_survey_responses.Where(r => r.location_id == areaId).ToList();
                return View(surveys);
            }
            else if (UserManager.IsInRole(userId, "MarketDeveloper"))
            {
                var marketDev = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                int makDevId = Convert.ToInt32(marketDev.area_code.Substring(marketDev.area_code.Length - 1));
                List<all_survey_responses> surveys = db.all_survey_responses.Where(r => r.location_id == makDevId ).ToList();
                
                return View(surveys);
            }
            else
            {
                var regionalManager = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
                int regionId = Convert.ToInt32(regionalManager.region_code);
                List<all_survey_responses> surveys = db.all_survey_responses.Where(r => r.region_id == regionId ).ToList();
                
                return View(surveys);
            }

        }

        public ActionResult Survey(int Id)
        {
            List<all_survey_responses> surveys = db.all_survey_responses.Where(s => s.SurveyId == Id).ToList();
            return View(surveys);
        }
    }
}