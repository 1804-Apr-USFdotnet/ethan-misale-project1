using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Models;

namespace RestaurantReviews.Library
{
    public static class RestaurantGet
    {

        public static List<Restaurant> GetRestaurants()
        {
           return DeseralizeItems.Deseralize<List<Restaurant>>(@"D:\revature\misale-ethan-project0\RestaurantInfo.txt");
        }
    }
}
