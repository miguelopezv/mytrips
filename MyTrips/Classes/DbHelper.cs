﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTrips.Classes
{
    public class DbHelper
    {
        public DbHelper()
        {
        }

        //Method to be called to insert info into DB
        public static bool insert<T>(ref T item, string dbRoute)
        {
            // keyword 'using' so there's only one instance of the connection
            using (SQLite.SQLiteConnection conection = new SQLite.SQLiteConnection(dbRoute))
            {
                conection.CreateTable<T>();

                if(conection.Insert(item) > 0) {
                    return true;
                };

            }
            return false;
        }
        
        public static List<Trip> returnTrips(string dbRoute)
        {
            List<Trip> trips = new List<Trip>();

            using (SQLite.SQLiteConnection conection = new SQLite.SQLiteConnection(dbRoute))
            {
                trips = conection.Table<Trip>().ToList();
            }

            return trips;
        }
    }
}
