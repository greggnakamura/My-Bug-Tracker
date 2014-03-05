using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBugTracker;
using PetaPoco;
using My_Bug_Tracker.Helpers;

namespace My_Bug_Tracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = getDBConnection();

            double bugsReported = db.ExecuteScalar<long>("SELECT Count(*) FROM Bug");
            double bugsResolved = db.ExecuteScalar<long>("SELECT Count(*) FROM Bug WHERE Status = 'Resolved'");

            ViewBag.NumberOfBugsReported = bugsReported;
            ViewBag.NumberOfBugsResolved = bugsResolved;

            double calculatePercentage = bugsResolved / bugsReported;
            ViewBag.ResolutionPercentage = String.Format("{0:p0}", calculatePercentage);

            return View();
        }

        /// <summary>
        /// Create Bug / Issue
        /// </summary>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(Bug bugModel)
        {
            if (ModelState.IsValid) 
            { 
                // New bug object
                var newBug = new Bug();

                // Set data
                newBug.Issue = bugModel.Issue;
                newBug.Cause = bugModel.Cause;
                newBug.Resolution = bugModel.Resolution;
                newBug.Comments = bugModel.Comments;
                newBug.Rating = bugModel.Rating;
                newBug.Tag = bugModel.Tag;

                newBug.Save();

                return RedirectToAction("Index");
            }   
            return View();
        }

        /// <summary>
        /// Edit Bug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var bug = Bug.SingleOrDefault(id);
            return View(bug);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, Bug bugModel)
        {
            if(ModelState.IsValid)
            {
                var bug = Bug.SingleOrDefault(id);

                bug.Issue = bugModel.Issue;
                bug.Cause = bugModel.Cause;
                bug.Status = bugModel.Status;
                bug.Resolution = bugModel.Resolution;
                bug.Comments = bugModel.Comments;
                bug.Rating = bugModel.Rating;
                bug.Tag = bugModel.Tag;
                bug.LastModified = DateTime.Now;

                bug.Save();

                return RedirectToAction("Index");
            }
            return View();
        }

        /// <summary>
        /// Bug Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id) 
        {
            var bug = Bug.SingleOrDefault(id);
            return View(bug);
        }

        /// <summary>
        /// Delete Bug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var bug = Bug.SingleOrDefault(id);
            return View(bug);
        }

        [HttpPost]
        public ActionResult Delete(int id, Bug bugModel)
        {
            var golfer = Bug.SingleOrDefault(id);

            if (ModelState.IsValid)
            {
                bugModel.BugId = id;
                bugModel.Delete();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        /// <summary>
        /// Tag Navigation
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _Tags()
        {
            var db = getDBConnection();
            var tags = db.Query<Bug>("SELECT Tag FROM Bug ORDER BY Tag ASC");

            //var listTags = new List<string>();

            //foreach (var item in tags)
            //{

            //    List<String> items = item.
            //    listTags.Add(items);
            //}
            return PartialView("_Tags", tags);
        }        


        /// <summary>
        /// PV: Get all bugs
        /// </summary>
        /// <returns></returns>
        public PartialViewResult _Bugs()
        {
            var bugs = Bug.Fetch("Order By BugId DESC");
            return PartialView("_Bugs", bugs);
        }


        private static Database getDBConnection()
        {
            var db = new Database(ConnectionHelper.ConnectionStringName);
            return db;
        }
    }
}
