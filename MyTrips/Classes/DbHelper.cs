using System;
namespace MyTrips.Classes
{
    public class DbHelper
    {
        public DbHelper()
        {
        }

        public static bool insert<T>(ref T item, string dbRoute)
        {
            using (SQLite.SQLiteConnection conection = new SQLite.SQLiteConnection(dbRoute))
            {
                conection.CreateTable<T>();

                if(conection.Insert(item) > 0) {
                    return true;
                };

            }
            return false;
        }
    }
}
