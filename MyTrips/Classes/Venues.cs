using System;
using System.Collections.Generic;

namespace MyTrips.Classes
{
    public class Venues
    {
        public Meta meta { get; set; }
        public Response response { get; set; }
    }

    public class Response
    {
        public List<Venue> venues { get; set; }
        public bool confident { get; set; }
        public Geocode geocode { get; set; }
    }

    public class Geocode
    {
        public string what { get; set; }
        public string where { get; set; }
        public Feature feature { get; set; }
        public List<object> parents { get; set; }
    }

    public class Feature
    {
        public string cc { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string matchedName { get; set; }
        public string highlightedName { get; set; }
        public int woeType { get; set; }
        public string slug { get; set; }
        public string id { get; set; }
        public string longId { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public Center center { get; set; }
        public Bounds bounds { get; set; }
    }

    public class Center
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Ne
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Sw
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Ne ne { get; set; }
        public Sw sw { get; set; }
    }

    public class Meta
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class Contact
    {
        public string phone { get; set; }
        public string formattedPhone { get; set; }
        public string twitter { get; set; }
        public string facebook { get; set; }
        public string facebookUsername { get; set; }
        public string facebookName { get; set; }
        public string instagram { get; set; }
    }

    public class LabeledLatLng
    {
        public string label { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
        public IList<LabeledLatLng> labeledLatLngs { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public IList<string> formattedAddress { get; set; }
        public string postalCode { get; set; }
        public string address { get; set; }
        public string crossStreet { get; set; }
        public string neighborhood { get; set; }
    }

    public class Icon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public Icon icon { get; set; }
        public bool primary { get; set; }
    }

    public class Stats
    {
        public int tipCount { get; set; }
        public int usersCount { get; set; }
        public int checkinsCount { get; set; }
    }

    public class BeenHere
    {
        public int lastCheckinExpiredAt { get; set; }
    }

    public class Specials
    {
        public int count { get; set; }
        public IList<object> items { get; set; }
    }

    public class Group
    {
        public string type { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public IList<object> items { get; set; }
    }

    public class HereNow
    {
        public int count { get; set; }
        public string summary { get; set; }
        public IList<Group> groups { get; set; }
    }

    public class Menu
    {
        public string type { get; set; }
        public string label { get; set; }
        public string anchor { get; set; }
        public string url { get; set; }
        public string mobileUrl { get; set; }
    }

    public class VenuePage
    {
        public string id { get; set; }
    }

    public class Venue
    {
        public string id { get; set; }
        public string name { get; set; }
        public Contact contact { get; set; }
        public Location location { get; set; }
        public IList<Category> categories { get; set; }
        public bool verified { get; set; }
        public Stats stats { get; set; }
        public bool allowMenuUrlEdit { get; set; }
        public BeenHere beenHere { get; set; }
        public Specials specials { get; set; }
        public HereNow hereNow { get; set; }
        public string referralId { get; set; }
        public IList<object> venueChains { get; set; }
        public bool hasPerk { get; set; }
        public bool? venueRatingBlacklisted { get; set; }
        public string storeId { get; set; }
        public string url { get; set; }
        public bool? hasMenu { get; set; }
        public Menu menu { get; set; }
        public VenuePage venuePage { get; set; }

		public override string ToString()
		{
            return name;
		}
	}
}
