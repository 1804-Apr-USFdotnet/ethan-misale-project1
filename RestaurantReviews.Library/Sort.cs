using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantReviews.Library
{
    class Sort
    {
        public static List<Restaurant> SortAscending(List<Restaurant> restaurants)
        {
            return restaurants.OrderBy(r => r.Name).ToList();
        }

        public static List<Restaurant> SortDescending(List<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(r => r.Name).ToList();
        }
    }
}
