using System;
using SQLite;

namespace MyTrips.Classes
{
    public class Trip
    {
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
    }
}
