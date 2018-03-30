using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyTrips.Classes.Helpers
{
    public class Foursquare
    {
        public async Task<List<Categories.Category>> getCategories() 
        {
            List<Categories.Category> categories = new List<Categories.Category>();

            string url = Constants.ObtainCategoriesURL();

            using(HttpClient client = new HttpClient())
            {
                string answer = await client.GetStringAsync(url);
                Categories response = JsonConvert.DeserializeObject<Categories>(answer);
                categories = response.response.categories;
            }

            return categories;
        }

        public async Task<List<Venue>> getVenues(string city, string categoryId)
        {
            List<Venue> venues = new List<Venue>();

            string url = Constants.ObtainVenuesURL(city, categoryId);

            using(HttpClient client = new HttpClient())
            {
                string answer = await client.GetStringAsync(url);
                Venues response = JsonConvert.DeserializeObject<Venues>(answer);
                venues = response.response.venues;
            }

            return venues;
        }
    }
}
