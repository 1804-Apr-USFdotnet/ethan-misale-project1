using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [Range (1,5)]
        public double Rating { get; set; }
        [Required]
        public string Comment { get; set; }
        public int RestaurantId { get; set; }
    }


}
