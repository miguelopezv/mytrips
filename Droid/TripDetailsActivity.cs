
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
    [Activity(Label = "TripDetailsActivity")]
    public class TripDetailsActivity : Activity
    {
        Toolbar tripDetailsToolbar;
        TextView dateTextView, cityTextView;
        ListView tripDetailsListView;

        string selectedCity, departureDate, returnDate;
        int selectedCityId;
        List<InterestSite> interestSitesList;

        static string fileName = "trips_db.sqlite";
        static string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        string fullPath = Path.Combine(filePath, fileName);

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TripDetails);

            tripDetailsToolbar = FindViewById<Toolbar>(Resource.Id.TripDetailsToolbar);
            dateTextView = FindViewById<TextView>(Resource.Id.dateTextView);
            cityTextView = FindViewById<TextView>(Resource.Id.cityTextView);
            tripDetailsListView = FindViewById<ListView>(Resource.Id.tripDetailsListview);

            selectedCity = Intent.Extras.GetString("city");
            departureDate = Intent.Extras.GetString("departureDate");
            returnDate = Intent.Extras.GetString("returnDate");
            selectedCityId = Intent.Extras.GetInt("cityId");

            cityTextView.Text = selectedCity;
            dateTextView.Text = $"{departureDate} - {returnDate}";

            SetActionBar(tripDetailsToolbar);

            interestSitesList = DbHelper.returnInterestSite(selectedCityId, fullPath);
            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, interestSitesList);

            tripDetailsListView.Adapter = arrayAdapter;

            cityTextView.Click += CityTextView_Click;
        }

        void CityTextView_Click(object sender, EventArgs e)
        {
            double[] latitudes = new double[interestSitesList.Count], longitudes = new double[interestSitesList.Count];

            int count = 0;
            foreach (var place in interestSitesList)
            {
                latitudes[count] = place.Lat;
                longitudes[count] = place.Lng;
                count++;
            }

            Intent intent = new Intent(this, typeof(MapActivity));

            Bundle bundle = new Bundle();
            bundle.PutDoubleArray("latitudes", latitudes);
            bundle.PutDoubleArray("longitudes", longitudes);

            intent.PutExtras(bundle);

            StartActivity(intent);
        }


		protected override void OnRestart()
		{
			base.OnRestart();

            interestSitesList = DbHelper.returnInterestSite(selectedCityId, fullPath);
            ArrayAdapter arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, interestSitesList);

            tripDetailsListView.Adapter = arrayAdapter;
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.Add, menu);

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            if(item.TitleFormatted.ToString() == "Add")
            {
                Intent intent = new Intent(this, typeof(NewPlaceActivity));

                Bundle bundle = new Bundle();

                bundle.PutInt("cityId", selectedCityId);
                bundle.PutString("city", selectedCity);

                StartActivity(intent.PutExtras(bundle));
            }
			return base.OnOptionsItemSelected(item);
		}
	}
}
