using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestaurantReviews.Models;


namespace RestaurantReviews.Library
{
    public class SerializeItems
    {
        public static void Seralize(object item)
        {
            string result = JsonConvert.SerializeObject(item);
            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["JsonWrite"], result);
        }

    }
}
