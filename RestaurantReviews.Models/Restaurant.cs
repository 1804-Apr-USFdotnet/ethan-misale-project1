using RestaurantReviews.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;



        
namespace RestaurantReviews.Models
{      
    
    public class Restaurant:IReviewable
    {
        public int Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Address { get; set; }

        public List<Review> Reviews { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
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
