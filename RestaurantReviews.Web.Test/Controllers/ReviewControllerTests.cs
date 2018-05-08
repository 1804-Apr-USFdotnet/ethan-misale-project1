using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using RestaurantReviews.Models;
using RestaurantReviews.Web.Controllers;

namespace RestaurantReviews.Web.Test.Controllers
{
    [TestClass]
    public class ReviewControllerTests
    {
        [TestMethod]
        public void DetailsTest()
        {
            ReviewController controller = new ReviewController();

            var details = controller.Details(1) as ViewResult;
            var actual = details.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void DetailsDataTest()
        {
            ReviewController controller = new ReviewController();

            var result = controller.Details(4) as ViewResult;
            var data = result.Model as List<Review>;

            Assert.AreEqual("Restaurant was great", data[0].Comment);
        }

        [TestMethod]
        public void EditTest()
        {
            ReviewController controller = new ReviewController();

            var editData = controller.Edit(4) as ViewResult;
            var actual = editData.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void EditDataTest()
        {
            ReviewController controller = new ReviewController();

            var result = controller.Edit(4) as ViewResult;
            var data = result.Model as Review;

            Assert.AreEqual("Place was alright", data.Comment);
        }

        [TestMethod]
        public void DeletTest()
        {
            ReviewController controller = new ReviewController();

            var delete = controller.Delete(4) as ViewResult;
            var actual = delete.Model;

            Assert.IsNotNull(actual);
        }
    }
}
