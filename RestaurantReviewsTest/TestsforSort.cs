using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Library;
using RestaurantReviews.Models;
using System.Collections.Generic;
using NLog.Config;
using NLog;
using NLog.Targets;

namespace RestaurantReviewsTest
{
    [TestClass]
    public class TestsforSort
    {
        private Restaurant rest1 = new Restaurant{

            Name = "Foodbean",
            Address = "4176  dklskldlksa",
            PhoneNumber = "8605643225",
            City = "Tampa",
            State = "Florida",
            Reviews = reviews1
        };
        private Restaurant rest2 = new Restaurant {
  
            Name = "Yakidoo",
            Address = "5 Tennessee Avenue",
            PhoneNumber = "941-412-3214",
            City = "Bradenton",
            State = "Florida",
            Reviews = reviews2
        };
        private Restaurant rest3 = new Restaurant
        {
            Name = "Blogtags",
            Address = "4176 Transport Avenue",
            PhoneNumber = "850-305-1338",
            City = "Panama City",
            State = "Florida",
            Reviews = reviews3

        };
        private static List<Review> reviews1 = new List<Review>();
        private static List<Review> reviews2 = new List<Review>();
        private static List<Review> reviews3 = new List<Review>();
        private Review review1 = new Review
        {
            Id = 1,
            Comment = "Restaurant was great",
            Rating = 4,
            RestaurantId = 1
        };
        private Review review2 = new Review
        {
            Id = 2,
            Comment = "Restaurant was great",
            Rating = 1,
            RestaurantId = 3
        };
        private Review review3 = new Review
        {
            Id = 1,
            Comment = "Restaurant was great",
            Rating = 5,
            RestaurantId = 1
        };
        private Review review4 = new Review
        {
            Id = 2,
            Comment = "Restaurant was great",
            Rating = 2,
            RestaurantId = 3
        };
        private Review review5 = new Review
        {
            Id = 1,
            Comment = "Restaurant was great",
            Rating = 5,
            RestaurantId = 1
        };
        private Review review6 = new Review
        {
            Id = 2,
            Comment = "Restaurant was great",
            Rating = 4,
            RestaurantId = 3
        };

        // [TestMethod]
        private List<Restaurant> restaurants = new List<Restaurant>();
        [TestMethod]
        public void SortAscending()
        {
    
            reviews1.Add(review1);
            reviews1.Add(review2);
            reviews2.Add(review3);
            reviews2.Add(review4);
            reviews3.Add(review5);
            reviews3.Add(review6);

            restaurants.Add(rest1);
            restaurants.Add(rest2);
            restaurants.Add(rest3);

            List<Restaurant> sortedList = (List<Restaurant>)Sort1.SortAscending(restaurants);
            Restaurant actual = restaurants[2];
            Restaurant expected = sortedList[0];

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortDescending()
        {

            reviews1.Add(review1);
            reviews1.Add(review2);
            reviews2.Add(review3);
            reviews2.Add(review4);
            reviews3.Add(review5);
            reviews3.Add(review6);

            restaurants.Add(rest1);
            restaurants.Add(rest2);
            restaurants.Add(rest3);

            List<Restaurant> sortedList = (List<Restaurant>)Sort1.SortDescending(restaurants);
            Restaurant actual = restaurants[1];
            Restaurant expected = sortedList[0];

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SortTopRating()
        {
            Logger log = LogManager.GetCurrentClassLogger();

            reviews1.Add(review1);
            reviews1.Add(review2);
            reviews2.Add(review3);
            reviews2.Add(review4);
            reviews3.Add(review5);
            reviews3.Add(review6);

            restaurants.Add(rest1);
            restaurants.Add(rest2);
            restaurants.Add(rest3);

            List<Restaurant> sortedList = (List<Restaurant>)Sort1.SortTopRating(restaurants);
            Restaurant actual = restaurants[2];
            Restaurant expected = sortedList[0];
           
            Assert.AreEqual(expected, actual);
            log.Info("Test Passed");
        }

        [TestMethod]
        public void SortTop3Rating()
        {

            reviews1.Add(review1);
            reviews1.Add(review2);
            reviews2.Add(review3);
            reviews2.Add(review4);
            reviews3.Add(review5);
            reviews3.Add(review6);

            restaurants.Add(rest1);
            restaurants.Add(rest2);
            restaurants.Add(rest3);

            List<Restaurant> sortedList = (List<Restaurant>)Sort1.SortTop3Rating(restaurants);
            Restaurant actual = restaurants[2];
            Restaurant expected = sortedList[0];

            Assert.AreEqual(expected, actual);
        }

    }
}
