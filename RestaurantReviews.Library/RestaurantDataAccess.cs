using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestuarantReviews.DAL;



namespace RestaurantReviews.Library
{
    public class RestaurantDataAccess
    {
        RestaurantCRUD crud = new RestaurantCRUD();
        
        public IEnumerable<Models.Restaurant> ShowRestaurants()
        {

           var show =  crud.ShowRestaurants();
           var test = new List<Models.Restaurant>();
           foreach(Restaurant rest in show)
            {
                var show1 = DataToLibraryRestaurant(rest);
                show1.CalculateAverageRating();
                test.Add(show1);
            }

            return test;

        }

        public Models.Restaurant SearchByRestaurantID(int id)
        {
           var search = crud.SearchByRestaurantID(id);
           var show =  DataToLibraryRestaurant(search);
           show.CalculateAverageRating();

            return show;
        }

        public void InsertRestaurant(RestaurantReviews.Models.Restaurant restaurant)
        {
            var rest = LibraryToDataRestaurant(restaurant);
            crud.InsertRestaurant(rest);
        }

        public void DeleteRestaurant(int id)
        {
           crud.DeleteRestaurant(id);
        }

        public void UpdateRestaurant(Models.Restaurant restaurant)
        {
            var rest = LibraryToDataRestaurant(restaurant);
            crud.UpdateRestaurant(rest);

        }

        public IEnumerable<Models.Review> ShowReviews()
        {

            var show = crud.ShowReviews();
            var test = new List<Models.Review>();
            foreach (Review rev in show)
            {
                var show1 = DataToLibraryReview(rev);
                test.Add(show1);
            }

            return test;

        }


        public Models.Review SearchByReviewID(int id)
        {
            var search = crud.SearchByReviewID(id);
            var show = DataToLibraryReview(search);
            return show;
        }

        public IEnumerable<Models.Review> ShowReviewsByRestaurantId(int restId)
        {
            var show = crud.ShowReviewsByRestaurantId(restId);
            var singleRest = new List<Models.Review>();
            foreach (Review rev in show)
            {
                var show1 = DataToLibraryReview(rev);
                singleRest.Add(show1);
            }
            return singleRest;
        }

        public void InsertReview(RestaurantReviews.Models.Review review)
        {
            var convert = LibraryToDataReview(review);
            crud.InsertReview(convert);
        }

        public void DeleteReview(int id)
        {
            crud.DeleteReview(id);
        }

        public void UpdateReview(Models.Review review)
        {
            var rev = LibraryToDataReview(review);
            crud.UpdateReview(rev);

        }

        public IEnumerable<Models.Restaurant> SearchByPartialName(string name)
        {
            var nameLow = name.ToLower();
            var part = crud.SearchByPartialName(nameLow);
            var test = new List<Models.Restaurant>();
            foreach (Restaurant rest in part)
            {
                var show1 = DataToLibraryRestaurant(rest);
                show1.CalculateAverageRating();
                test.Add(show1);
            }
            return test;
        }


        public static Restaurant LibraryToDataRestaurant(RestaurantReviews.Models.Restaurant restaurant)
        {
            //var revs = new List<Review>();
            //foreach (Models.Review rev in restaurant.Reviews)
            //{
            //    revs.Add(LibraryToDataReview(rev));
            //}
            Restaurant rest = new Restaurant()
            {
                Address = restaurant.Address,
                City = restaurant.City,
                PhoneNumber = restaurant.PhoneNumber,
                State = restaurant.State,
                Id = restaurant.Id,
                Name = restaurant.Name,


            };

            return rest;
        }

        public static RestaurantReviews.Models.Restaurant DataToLibraryRestaurant(Restaurant restaurant)
        {
            var revs = new List<Models.Review>();
            foreach (Review rev in restaurant.Reviews)
            {
                revs.Add(DataToLibraryReview(rev));
            }
            RestaurantReviews.Models.Restaurant rest = new RestaurantReviews.Models.Restaurant()
            {
                Address = restaurant.Address,
                City = restaurant.City,
                PhoneNumber = restaurant.PhoneNumber,
                State = restaurant.State,
                Id = restaurant.Id,
                Name = restaurant.Name,
                Reviews = revs

            };
            if (restaurant.AvgRating is null)
            {
                rest.AvgRating = 0;
            }
            else
            {
                rest.AvgRating = (double)(restaurant.AvgRating);
            }


            return rest;
        }

        public static Review LibraryToDataReview(RestaurantReviews.Models.Review review)
        {
            Review rev = new Review()
            {
                Id = review.Id,
                Comment = review.Comment,
                RestaurantId = review.RestaurantId,
                Rating = review.Rating

            };

            return rev;
        }

        public static RestaurantReviews.Models.Review DataToLibraryReview(Review review)
        {
            RestaurantReviews.Models.Review rev = new RestaurantReviews.Models.Review()
            {
                Id = review.Id,
                Comment = review.Comment,
                RestaurantId = review.RestaurantId,
                Rating = review.Rating
            };

            return rev;

        }
    }
}
