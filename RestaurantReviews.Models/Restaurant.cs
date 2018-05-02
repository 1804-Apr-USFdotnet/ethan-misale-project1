using RestaurantReviews.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


        
namespace RestaurantReviews.Models
{      
    
    public class Restaurant:IReviewable
    {
        public int Id { get; set; }

        public string  Name { get; set; }
        
        public string Address { get; set; }

        public List<Review> Reviews { get; set; }
        
        public string PhoneNumber { get; set; }
       
        public string City { get; set; }
     
        public string State { get; set; }
        [JsonIgnore]
        public double AvgRating { get; set; }

        public double CalculateAverageRating()
        {

            AvgRating = 0;

            foreach (var i in Reviews)
            {
                AvgRating += i.Rating;
            }

            return (double)(AvgRating /= Reviews.Count);
        }


            public void AddReview(Review review)
        {

            Reviews.Add(review);
        }



    }
}
