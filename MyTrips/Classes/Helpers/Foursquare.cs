using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyTrips.Classes.Helpers
{
    public class Foursquare
    {
        public async Task<List<Category>> getCategories() 
        {
            List<Category> categories = new List<Category>();

            string url = Constants.ObtainCategoriesURL();

            using(HttpClient client = new HttpClient())
            {
                string answer = await client.GetStringAsync(url);
                Categories response = JsonConvert.DeserializeObject<Categories>(answer);

                categories = response.response.categories;
            }

            return categories;
        }

        public async Task<List<Venue>> getSearchResult()
        {
            List<Venue> venues = new List<Venue>();

            string url = Constants.ObtainSearchURL("Chicago, Fl");

            using(HttpClient client = new HttpClient())
            {
                string answer = await client.GetStringAsync(url);
                SearchResult response = JsonConvert.DeserializeObject<SearchResult>(answer);

                venues = response.response.venues;
            }

            return venues;
        }
    }
}
