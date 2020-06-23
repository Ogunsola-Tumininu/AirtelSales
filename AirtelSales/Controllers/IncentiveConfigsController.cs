using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AirtelSales.DAL;
using Microsoft.AspNet.Identity.EntityFramework;
using AirtelSales.Models;

namespace AirtelSales.Controllers
{
    public class IncentiveConfigsController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: IncentiveConfigs
        public ActionResult Index()
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var userName = db.sf_user_profiles.FirstOrDefault(p =>p.PROFILE_ID == user.ProfileId).USER_ID;
            //if (UserManager.IsInRole(userId, "ZonalManager"))
            //{
            //    userName = db.ZonalManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}

            //else if (UserManager.IsInRole(userId, "AreaManager"))
            //{
            //    userName = db.AreaManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}
            //else if (UserManager.IsInRole(userId, "MarketDeveloper"))
            //{
            //    userName = db.MarketDevelopers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}
            //else
            //{
            //    userName = db.RegionalManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}

            return View(db.IncentiveConfigs.Where(u => u.created_by == userName).ToList());
        }

        // GET: IncentiveConfigs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncentiveConfig incentiveConfig = db.IncentiveConfigs.Find(id);
            if (incentiveConfig == null)
            {
                return HttpNotFound();
            }
            return View(incentiveConfig);
        }

        // GET: IncentiveConfigs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncentiveConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,quarter,orsc,bts,created_by,created_at")] IncentiveConfig incentiveConfig)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var userName = db.sf_user_profiles.FirstOrDefault(p => p.PROFILE_ID == user.ProfileId).USER_ID;
            //if (UserManager.IsInRole(userId, "ZonalManager"))
            //{
            //    userName = db.ZonalManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}

            //else if (UserManager.IsInRole(userId, "AreaManager"))
            //{
            //    userName = db.AreaManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}
            //else if (UserManager.IsInRole(userId, "MarketDeveloper"))
            //{
            //    userName = db.MarketDevelopers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}
            //else
            //{
            //    userName = db.RegionalManagers.Where(u => u.UserId == userId).FirstOrDefault().Name;
            //}
            incentiveConfig.created_by = userName;
            incentiveConfig.created_at = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.IncentiveConfigs.Add(incentiveConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(incentiveConfig);
        }

        // GET: IncentiveConfigs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncentiveConfig incentiveConfig = db.IncentiveConfigs.Find(id);
            if (incentiveConfig == null)
            {
                return HttpNotFound();
            }
            return View(incentiveConfig);
        }

        // POST: IncentiveConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,quarter,orsc,bts,created_by,created_at")] IncentiveConfig incentiveConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incentiveConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(incentiveConfig);
        }

        // GET: IncentiveConfigs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncentiveConfig incentiveConfig = db.IncentiveConfigs.Find(id);
            if (incentiveConfig == null)
            {
                return HttpNotFound();
            }
            return View(incentiveConfig);
        }

        // POST: IncentiveConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncentiveConfig incentiveConfig = db.IncentiveConfigs.Find(id);
            db.IncentiveConfigs.Remove(incentiveConfig);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
