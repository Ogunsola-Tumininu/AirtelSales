using AirtelSales.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirtelSales.Controllers
{
    public class UsersController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();
        // GET: Users
        public ActionResult Index()
        {
            var users = db.AspNetUsers.ToList();
            return View(users);
        }

        public ActionResult DisableEnable(string Id)
        {
            var user = db.AspNetUsers.Find(Id);
            if (user.IsDisabled == false)
            {
                user.IsDisabled = true;
            }
            else
            {
                user.IsDisabled = false;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}