using System;
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
}
