﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using RestaurantReviews.Models;



namespace RestuarantReviews.DAL
{
    public class RestaurantCRUD
    {
        RestaurantDBEntities db = new RestaurantDBEntities();
            
        public  IEnumerable<Restaurant> ShowRestaurants()
        {
            return db.Restaurants.ToList();
        }

        public Restaurant SearchByRestaurantID(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            return restaurant;

        }

        public void InsertRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();

        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            db.Entry(restaurant).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Review> ShowReviews()
        {
            return db.Reviews.ToList();
        }

        public Review SearchByReviewID(int id)
        {
            Review review = db.Reviews.Find(id);
            return review;
        }

        public IEnumerable<Review> ShowReviewsByRestaurantId(int restId)
        {
            var reviews = db.Reviews.ToList();
            List<Review> singleRest = new List<Review>();
            foreach(Review rev in reviews)
            {
                if(rev.RestaurantId == restId)
                {
                    singleRest.Add(rev);
                }
            }
            return singleRest;
        }

        public void InsertReview(RestuarantReviews.DAL.Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();

        }

        public void UpdateReview(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
            db.SaveChanges();
        }


        public IEnumerable<Restaurant> SearchByPartialName(string name)
        {
            var part = name.Length;
            var rest = db.Restaurants.ToList();
            var partname = rest.FindAll(x => x.Name.ToLower().Contains(name));
            return partname;
        }


    }

}
