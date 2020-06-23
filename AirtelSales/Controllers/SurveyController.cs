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
    public class SurveyController : Controller
    {
        private AirtelSalesDBEntities db = new AirtelSalesDBEntities();

        // GET: Survey
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            if (user.Role == null)
            {
                return RedirectToAction("Index", "Profile");
            }

            ViewBag.SurveyType = db.survey_types.ToList();
            return View(db.survey_types.ToList());
        }

        public ActionResult List(int Id)
        {

            return View(db.all_surveys.Where(s => s.SurveyTypeId == Id));
        }

        public ActionResult SurveyType(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            List<all_survey_questions> survey = db.all_survey_questions.Where(s => s.SurveyId == id).ToList();
            ViewBag.Survey = db.all_surveys.Find(id);
            if (ViewBag.Survey == null)
            {
                return RedirectToAction("Index");
            }
            var marketer = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();
            ViewBag.RegionId = marketer.region_code;
            ViewBag.StateId = marketer.zonal_code.Substring(marketer.zonal_code.Length - 1);
            ViewBag.LocationId = marketer.area_code.Substring(marketer.area_code.Length - 1); ;
            return View(survey);
        }

        [HttpPost]
        public ActionResult SubmitSurvey(all_survey_responses resp)
        {
            var userId = User.Identity.GetUserId();
            resp.submission_date = DateTime.Now;
            if (ModelState.IsValid)
            {

                var newSurvey = db.all_survey_responses.Add(resp);
                var survey = db.all_surveys.Find(resp.SurveyId);
                survey.response_count = survey.response_count + 1;

                db.SaveChanges();

                return Json(new { Result = newSurvey.Id }, JsonRequestBehavior.AllowGet);

            }

            return Json(new { error = true, result = "Could not save Survey details" }, JsonRequestBehavior.AllowGet);

        }

        // GET: all_surveys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            all_surveys all_surveys = db.all_surveys.Find(id);
            if (all_surveys == null)
            {
                return HttpNotFound();
            }
            return View(all_surveys);
        }

        // GET: all_surveys/Create
        public ActionResult Create()
        {
            ViewBag.SurveyTypeId = new SelectList(db.survey_types, "Id", "SurveyType");
            return View();
        }

        // POST: all_surveys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SurveyTypeId,SurveyName,SurveryStartDate,SurveryExpiryDate,SurveyStatus")] all_surveys all_surveys)
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            var marketer = db.sf_user_profiles.Where(m => m.PROFILE_ID == user.ProfileId).FirstOrDefault();

            all_surveys.created_by = marketer.USER_ID;
            all_surveys.created_date = DateTime.Now;
            all_surveys.response_count = 0;
            all_surveys.SurveyStatus = 1;
            if (ModelState.IsValid)
            {
                db.all_surveys.Add(all_surveys);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SurveyTypeId = new SelectList(db.survey_types, "Id", "SurveyType", all_surveys.SurveyTypeId);
            return View(all_surveys);
        }

        // GET: all_surveys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            all_surveys all_surveys = db.all_surveys.Find(id);
            if (all_surveys == null)
            {
                return HttpNotFound();
            }
            ViewBag.SurveyTypeId = new SelectList(db.survey_types, "Id", "SurveyType", all_surveys.SurveyTypeId);
            return View(all_surveys);
        }

        // POST: all_surveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SurveyTypeId,SurveyName,SurveryStartDate,SurveryExpiryDate,SurveyStatus,created_date,created_by,response_count")] all_surveys all_surveys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(all_surveys).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SurveyTypeId = new SelectList(db.survey_types, "Id", "SurveyType", all_surveys.SurveyTypeId);
            return View(all_surveys);
        }

        // GET: all_surveys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            all_surveys all_surveys = db.all_surveys.Find(id);
            if (all_surveys == null)
            {
                return HttpNotFound();
            }
            return View(all_surveys);
        }



        // POST: all_surveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            all_surveys all_surveys = db.all_surveys.Find(id);
            db.all_surveys.Remove(all_surveys);
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
