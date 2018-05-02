using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestaurantReviews.Library
{
    public static class DeseralizeItems
    {
        
        public static T Deseralize<T>(string file)
        {
            T result = JsonConvert.DeserializeObject<T>(File.ReadAllText(file));

            return result;
        }

    }
}
