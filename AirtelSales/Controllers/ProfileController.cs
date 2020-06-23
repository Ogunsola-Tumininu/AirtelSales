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
    public class ProfileController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        // GET: Profile
        //public ActionResult Index()
        //{
        //    ViewBag.Roles = new SelectList(db.AspNetRoles.Where(r => r.Name != "Admin").ToList().OrderBy(s => s.Name), "Name", "Name");
        //    ViewBag.RegionalManagers = new SelectList(db.RegionalManagers.OrderBy(s => s.FirstName), "Id", "Name ");
        //    ViewBag.ZonalManagers = new SelectList(db.ZonalManagers.OrderBy(s => s.FirstName), "Id", "Name ");
        //    ViewBag.AreaManagers = new SelectList(db.AreaManagers.OrderBy(s => s.FirstName), "Id", "Name ");
        //    ViewBag.Areas = new SelectList(db.sales_areas.OrderBy(s => s.AreaName), "Id", "AreaName");
        //    ViewBag.Regions = new SelectList(db.sales_regions.OrderBy(s => s.RegionName), "Id", "RegionName");
        //    ViewBag.Zones = new SelectList(db.sales_zones.OrderBy(s => s.ZoneName), "Id", "ZoneName");
        //    ViewBag.Markets = new SelectList(db.Markets.OrderBy(s => s.Name), "Id", "Name");
        //    ViewBag.Dealers = new SelectList(db.Dealers.OrderBy(s => s.Name), "Id", "Name");
        //    ViewBag.SubDealers = new SelectList(db.SubDealers.OrderBy(s => s.Name), "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(Profile userProfile)
        //{
        //    string[] names = userProfile.Name.ToString().Trim().Split(new char[] { ' ' }, 2);
        //    var userId = User.Identity.GetUserId();

        //    ViewBag.Roles = new SelectList(db.AspNetRoles.OrderBy(s => s.Name), "Name", "Name");
        //    ViewBag.Areas = new SelectList(db.sales_areas.OrderBy(s => s.AreaName), "Id", "AreaName");
        //    ViewBag.Regions = new SelectList(db.sales_regions.OrderBy(s => s.RegionName), "Id", "RegionName");
        //    ViewBag.Zones = new SelectList(db.sales_zones.OrderBy(s => s.ZoneName), "Id", "ZoneName");
        //    ViewBag.Markets = new SelectList(db.Markets.OrderBy(s => s.Name), "Id", "Name");
        //    ViewBag.RegionalManagers = new SelectList(db.RegionalManagers.OrderBy(s => s.FirstName), "Id", "Name");
        //    ViewBag.ZonalManagers = new SelectList(db.ZonalManagers.OrderBy(s => s.FirstName), "Id", "Name ");
        //    ViewBag.AreaManagers = new SelectList(db.AreaManagers.OrderBy(s => s.FirstName), "Id", "Name ");
        //    ViewBag.Dealers = new SelectList(db.Dealers.OrderBy(s => s.Name), "Id", "Name");
        //    ViewBag.SubDealers = new SelectList(db.SubDealers.OrderBy(s => s.Name), "Id", "Name");

        //    if (userProfile.Role == "RegionalManager")
        //    {
        //        var user = new RegionalManager
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            RegionId = (int)userProfile.RegionId
        //        };
        //        db.RegionalManagers.Add(user);

        //    }
        //    else if (userProfile.Role == "ZonalManager")
        //    {
        //        if (userProfile.RegionalManagerId == 0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var user = new ZonalManager
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZoneId = (int)userProfile.ZoneId

        //        };

        //        db.ZonalManagers.Add(user);

        //    }
        //    else if (userProfile.Role == "AreaManager")
        //    {
        //        if (userProfile.RegionalManagerId == 0 || userProfile.ZonalManagerId == 0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var user = new AreaManager
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZonalManagerId = (int)userProfile.ZonalManagerId,
        //            AreaId = (int)userProfile.AreaId

        //        };

        //        db.AreaManagers.Add(user);
        //    }
        //    else if (userProfile.Role == "MarketDeveloper")
        //    {
        //        if (userProfile.RegionalManagerId == 0 || userProfile.ZonalManagerId == 0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var user = new MarketDeveloper
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            MarketId = (int)userProfile.MarketId,
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZonalManagerId = (int)userProfile.ZonalManagerId,
        //            AreaManagerId = (int)userProfile.AreaManagerId,


        //        };
        //        db.MarketDevelopers.Add(user);
        //    }

        //    else if (userProfile.Role == "Dealer")
        //    {
        //        if (userProfile.RegionalManagerId == 0 || userProfile.ZonalManagerId == 0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var mkt = db.MarketDevelopers.Where(m => m.MarketId == (int)userProfile.MarketId).FirstOrDefault().Id;
        //        var user = new Dealer
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            MarketDeveloperId = (int)mkt,
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZonalManagerId = (int)userProfile.ZonalManagerId,
        //            AreaManagerId = (int)userProfile.AreaManagerId,
        //            DealerCode = userProfile.DealerCode


        //        };
        //        db.Dealers.Add(user);
        //    }

        //    else if (userProfile.Role == "SubDealer")
        //    {
        //        if (userProfile.RegionalManagerId == 0 || userProfile.ZonalManagerId  ==0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var mkt = db.MarketDevelopers.Where(m => m.MarketId == (int)userProfile.MarketId).FirstOrDefault().Id;
        //        var user = new SubDealer
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            MarketDeveloperId = (int)mkt,
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZonalManagerId = (int)userProfile.ZonalManagerId,
        //            AreaManagerId = (int)userProfile.AreaManagerId,
        //            DealerId = (int)userProfile.DealerId,
        //            SubDealerCode = userProfile.DealerCode


        //        };
        //        db.SubDealers.Add(user);
        //    }

        //    else if (userProfile.Role == "Reseller")
        //    {
        //        if (userProfile.RegionalManagerId == 0 || userProfile.ZonalManagerId == 0)
        //        {
        //            ViewBag.ErrorMessage = "Please fill in all fields";
        //            return View();
        //        }
        //        var mkt = db.MarketDevelopers.Where(m => m.MarketId == (int)userProfile.MarketId).FirstOrDefault().Id;
        //        var user = new Reseller
        //        {
        //            UserId = userId,
        //            Name = userProfile.Name,
        //            FirstName = names[0],
        //            LastName = names[1],
        //            MarketDeveloperId = (int)mkt,
        //            RegionalManagerId = (int)userProfile.RegionalManagerId,
        //            ZonalManagerId = (int)userProfile.ZonalManagerId,
        //            AreaManagerId = (int)userProfile.AreaManagerId,
        //            DealerId = (int)userProfile.DealerId,
        //            SubDealerId = (int)userProfile.SubDealerId,
        //            ResellerCode = userProfile.DealerCode


        //        };
        //        db.Resellers.Add(user);
        //    }

        //    ApplicationDbContext context = new Models.ApplicationDbContext();
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        //    var newUser = db.AspNetUsers.Find(userId);
        //    newUser.Role = userProfile.Role;
        //    var result1 = UserManager.AddToRole(userId, userProfile.Role);

        //    db.SaveChanges();
        //    return RedirectToAction("Index", "Survey");
           
        //   }
      }
}