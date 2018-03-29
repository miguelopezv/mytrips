using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyTrips.Classes.Helpers;
using Newtonsoft.Json;

namespace MyTrips.Classes
{
    public class Foursquare
    {
        public async Task<List<Categories.Category>> getCategories() 
        {
            List<Categories.Category> categories = new List<Categories.Category>();

            var url = Constants.ObtainCategoriesURL();

            using(HttpClient client = new HttpClient())
            {
                var answer = await client.GetStringAsync(url);
                Categories response = JsonConvert.DeserializeObject<Categories>(answer);

                categories = response.response.categories;

            }

            return categories;
        }
    }
}
