using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Library;
using System.Collections.Generic;
using RestaurantReviews.Models;
using System.Data.Entity;


namespace RestaurantReviewsTest
{
    [TestClass]
    public class GetRestaurants_Test
    {
        [TestMethod]
        public void GetRestaurantsUsingClass_Test()
        {
            List<Restaurant> restTest = new List<Restaurant>(RestaurantGet.GetRestaurants());


            Restaurant expected = new Restaurant
            {
                Name = "Miboo",
                Address = "9 5th Hill",
                PhoneNumber = "727-962-8551",
                City = "Clearwater",
                State = "Florida",
                Reviews = new List<Review>()



            };
            expected.AddReview(new Review
            {
                Rating = 4.5f,
                Comment = "Restaurant was great"
            });

            bool areTheyEqual = false;
            Restaurant test = restTest[0];
            areTheyEqual = expected.Name.Equals(test.Name) && expected.Address.Equals(test.Address) &&
                expected.PhoneNumber.Equals(test.PhoneNumber) && expected.City.Equals(test.City) && expected.State.Equals(test.State);

            //if(areTheyEqual)
            //{
            //    //compare Reviews
            //}
            Assert.IsTrue(areTheyEqual);
        }
    }
}
