using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Controllers
{
    public class ReviewController : Controller
    {
        public RestaurantDataAccess da = new RestaurantDataAccess();
        // GET: Review
        public ActionResult Index()
        {
            return View(da.ShowReviews());
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.RestaurantName = (da.SearchByRestaurantID(id)).Name;
            return View(da.ShowReviewsByRestaurantId(id));
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            //ViewBag.RestaurantId = id;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
               
                if (ModelState.IsValid) {
                    Models.Review temp = new Models.Review
                    {
                    Comment = collection["Comment"],
                    Rating = double.Parse(collection["Rating"]),
                    RestaurantId = id

                    };
                    da.InsertReview(temp);
                    return RedirectToAction("Details", new { id = temp.RestaurantId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            return View(da.SearchByReviewID(id));
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid) {
                    Models.Review temp = new Models.Review
                    {
                        Id = id,
                        Comment = collection["Comment"],
                        Rating = double.Parse(collection["Rating"]),
                        RestaurantId = int.Parse(collection["RestaurantId"])
                    };

                    da.UpdateReview(temp);

                    return RedirectToAction("Details", new { id = temp.RestaurantId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View(da.SearchByReviewID(id));
        }

        // POST: Review/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.RestId = da.SearchByReviewID(id).RestaurantId;
                    da.DeleteReview(id);

                    return RedirectToAction("Details", new { id = ViewBag.RestId });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
