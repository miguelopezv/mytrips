﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyTrips.Classes;

namespace MyTrips.Droid
{
    [Activity(Label = "ListTripsActivity")]
    public class ListTripsActivity : Activity
    {
        List<Trip> tripLists;
        Toolbar tripsToolbar;
        ListView tripsList;

        static string fileName = "trips_db.sqlite";
        static string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string fullPath = Path.Combine(filePath, fileName);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ListTrips);

            tripsToolbar = FindViewById<Toolbar>(Resource.Id.tripToolbar);
            tripsList = FindViewById < ListView>(Resource.Id.tripsListView);

            SetActionBar(tripsToolbar);
            ActionBar.Title = "My Trips";

            this.getTrips(fullPath);
        }

		protected override void OnRestart()
		{
			base.OnRestart();
            this.getTrips(fullPath);
		}

        public void getTrips(string path) {
            tripLists = new List<Trip>();
            tripLists = DbHelper.returnTrips(path);

            var arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, tripLists);
            tripsList.Adapter = arrayAdapter;
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.Add, menu);

            return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            if (item.TitleFormatted.ToString() == "Add")
            {
                Intent intent = new Intent(this, typeof(NewTripActivity));

                StartActivity(intent);
            }
            return base.OnOptionsItemSelected(item);
		}
	}
}
