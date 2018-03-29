using System;

namespace MyTrips.Classes.Helpers
{
    public class Constants
    {
        public const string CLIENT_ID = "Y2V2NJG24NA0YU3UXHIAMPFZGZ3EHRYUGSCNKJXC3RCQ2151";
        public const string CLIENT_SECRET = "VTBZSSGMCO2QCFHWNPSISO4LHSB1JMRMM2BYL3LEIMKXYYTP";

        public static string ObtainCategoriesURL() {
            return $"https://api.foursquare.com/v2/venues/categories?client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";
        }

        public static string ObtainSearchURL(string city) {
            return $"https://api.foursquare.com/v2/venues/search?near={city}&client_id={CLIENT_ID}&client_secret={CLIENT_SECRET}&v={DateTime.Now.ToString("yyyyMMdd")}";
        }
    }
}

