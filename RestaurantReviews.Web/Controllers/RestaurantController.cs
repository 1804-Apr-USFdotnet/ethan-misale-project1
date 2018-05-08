using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantReviews.Library;
using RestaurantReviews.Models;


namespace RestaurantReviews.Web.Controllers
{
    public class RestaurantController : Controller
    {
        public RestaurantDataAccess da = new RestaurantDataAccess();
        // GET: Restaurant
        public ActionResult Index(string SearchString, string sort)
        {
            ViewBag.Search = SearchString;
            //IEnumerable<Restaurant> rest;
            if (!String.IsNullOrEmpty(SearchString)){
               View(da.SearchByPartialName(SearchString));
               
            }
            else
            {
               View(da.ShowRestaurants());
            }

            ViewBag.NameSortParm = sort == "name_asc" ? "name_desc" : "name_asc";
            ViewBag.TopRatingSortParm = sort == "TopRating" ? "rating_top" : "TopRating";
            ViewBag.Top3RatingSortParm = sort == "Top3Rating" ? "rating_top3" : "Top3Rating";


            switch (sort)
            {
                case "name_desc":
                   View( Sort1.SortDescending((List<Restaurant>)(da.ShowRestaurants())));
                    break;
                case "name_asc":
                    View( Sort1.SortAscending((List<Restaurant>)(da.ShowRestaurants())));
                    break;
                case "rating_top":
                    View(Sort1.SortTopRating((List<Restaurant>)(da.ShowRestaurants())));
                    break;
                case "rating_top3":
                    View(Sort1.SortTop3Rating((List<Restaurant>)(da.ShowRestaurants())));
                    break;
                default:
                    break;

            }
            return View();
        }

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
           
            return View(da.SearchByRestaurantID(id));
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.Restaurant temp = new Models.Restaurant
                    {
                        //Id = int.Parse(collection["Id"]),
                        Name = collection["Name"],
                        Address = collection["Address"],
                        City = collection["City"],
                        State = collection["State"],
                        PhoneNumber = collection["PhoneNumber"]
                    };

                    da.InsertRestaurant(temp);

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View(da.SearchByRestaurantID(id));
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Models.Restaurant temp = new Models.Restaurant
                    {
                        Id = id,
                        Name = collection["Name"],
                        Address = collection["Address"],
                        City = collection["City"],
                        State = collection["State"],
                        PhoneNumber = collection["PhoneNumber"],
                    };

                    da.UpdateRestaurant(temp);

                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View(da.SearchByRestaurantID(id));
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    da.DeleteRestaurant(id);

                    return RedirectToAction("Index");
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
