using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
        public int RestaurantId { get; set; }
    }


}
