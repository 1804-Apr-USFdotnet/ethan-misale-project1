using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantReviews.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using RestaurantReviews.Models;

namespace RestaurantReviews.Web.Controllers.Tests
{
    [TestClass()]
    public class RestaurantControllerTests
    {
        [TestMethod()]
        public void DetailsTest()
        {
            RestaurantController cont = new RestaurantController();

            var details = cont.Details(1) as ViewResult;
            var actual = details.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void DetailsDataUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var details = controller.Details(1) as ViewResult;
            var actual = details.Model as Restaurant;

            Assert.AreEqual("Clearwater", actual.City);
        }

        [TestMethod()]
        public void EditUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var edit = controller.Edit(1) as ViewResult;
            var actual = edit.Model;

            Assert.IsNotNull(actual);
        }

        [TestMethod()]
        public void EditDataUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var result = controller.Edit(1) as ViewResult;
            var data = result.Model as Restaurant;

            Assert.AreEqual("Clearwater", data.City);
        }

        [TestMethod()]
        public void DeleteUnitTest()
        {
            RestaurantController controller = new RestaurantController();

            var delete = controller.Delete(1) as ViewResult;
            var actual = delete.Model as Restaurant;

            Assert.IsNotNull(actual);
        }
    }
}