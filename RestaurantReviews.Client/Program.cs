using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;
using RestaurantReviews.Models;
using NLog;
using NLog.Config;
using NLog.Targets;



namespace RestaurantReviews.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //RestaurantReviews.Library.Restaurant restaurant = new Library.Restaurant()
            //{
            //    Id = 1,
            //    Name = "Miboo",
            //    Address = "9 5th Hill",
            //    PhoneNumber = "727-962-8551",
            //    City = "Clearwater",
            //    State = "Florida"

            //};

            //RestaurantCRUD restaurantCRUD = new RestaurantCRUD();
            //restaurantCRUD.InsertRestaurant(restaurant);
            //List<RestaurantReviews.Library.Restaurant> restTest = DeseralizeItems.Deseralize<List<RestaurantReviews.Library.Restaurant>>(@"D:\revature\misale-ethan-project0\RestaurantInfo.txt");
            //int k = 1;
            //for(int i = 0; i < restTest.Count ; i++)
            //{

            //    RestaurantReviews.Library.Restaurant restaurant = new Library.Restaurant();
            //    restaurant.Id = i + 1;
            //    restaurant.Name = restTest[i].Name;
            //    restaurant.PhoneNumber = restTest[i].PhoneNumber;
            //    restaurant.State = restTest[i].State;
            //    restaurant.Address = restTest[i].Address;
            //    restaurant.City = restTest[i].City;
            //    restaurantCRUD.InsertRestaurant(restaurant);
            //    for (int j = 0; j < restTest[i].Reviews.Count  ; j++, k++)
            //    {
            //        RestaurantReviews.Library.Review review = new Library.Review();
            //        review.Id = k;
            //        review.Rating = restTest[i].Reviews[j].Rating;
            //        review.Comment = restTest[i].Reviews[j].Comment;
            //        review.RestaurantId = i+1;
            //        restaurantCRUD.InsertReview(review);

            //    }


            RestaurantDataAccess access = new RestaurantDataAccess();
            
            
            List<Restaurant> show = (List<Restaurant>)access.ShowRestaurants();
           // var sortTop = Sort1.SortTop3Rating(show);
            foreach(Restaurant rest in show)
            {
                Console.WriteLine("Restaurant name: " + rest.Name );
            }
            
        }
    }
}
