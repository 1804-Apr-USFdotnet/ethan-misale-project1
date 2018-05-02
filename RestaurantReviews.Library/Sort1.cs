using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Models;

namespace RestaurantReviews.Library
{
    public class Sort1
    {

        public static IEnumerable<Restaurant> SortAscending(List<Restaurant> restaurants)
        {
            return restaurants.OrderBy(r => r.Name).ToList();
        }


        public static IEnumerable<Restaurant> SortDescending(List<Restaurant> restaurants)
        {

            return restaurants.OrderByDescending(r => r.Name).ToList();
        }


        public static IEnumerable<Restaurant> SortTopRating(List<Restaurant> restaurants)
        {

            return restaurants.OrderByDescending(r => r.CalculateAverageRating()).ToList();
        }

        public static IEnumerable<Restaurant> SortTop3Rating(List<Restaurant> restaurants)
        {
            var top3 = SortTopRating(restaurants).ToList();
            return top3.GetRange(0,3);
        }
    }
}
