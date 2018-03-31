using System;
using System.Linq;
using SQLite;

namespace MyTrips.Classes
{
    public class Trip
    {   
        //Defines Primary Key in SQLite DB
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }

        [MaxLength(150)]
        public string Place
        {
            get;
            set;
        }

        public DateTime DepartureDate
        {
            get;
            set;
        }

        public DateTime ReturnDate
        {
            get;
            set;
        }

        // Override method ToString [Available in all objects] to return string with specific format
		public override string ToString()
		{
            return $"{Place} ({DepartureDate:d} - {ReturnDate:d})";
		}
	}

    public class InterestSite
    {
        public InterestSite()
        {

        }

        public InterestSite(Venue venue, int tripId)
        {
            Name = venue.name;
            Lat = (float)venue.location.lat;
            Lng = (float)venue.location.lng;
            TripId = tripId;
            Category = venue.categories.First().name;
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public float Lat
        {
            get;
            set;
        }

        public float Lng
        {
            get;
            set;
        }

        public int TripId
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

		public override string ToString()
		{
            return Name;
		}
	}
}
