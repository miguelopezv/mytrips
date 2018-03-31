
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MyTrips.Droid
{
    [Activity(Label = "TripDetailsActivity")]
    public class TripDetailsActivity : Activity
    {
        Toolbar tripDetailsToolbar;
        TextView dateTextView, cityTextView;
        ListView tripDetailsTextView;

        string selectedCity, departureDate, returnDate;
        int selectedCityId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.TripDetails);

            tripDetailsToolbar = FindViewById<Toolbar>(Resource.Id.TripDetailsToolbar);
            dateTextView = FindViewById<TextView>(Resource.Id.dateTextView);
            cityTextView = FindViewById<TextView>(Resource.Id.cityTextView);
            tripDetailsTextView = FindViewById<ListView>(Resource.Id.tripDetailsListview);

            selectedCity = Intent.Extras.GetString("city");
            departureDate = Intent.Extras.GetString("departureDate");
            returnDate = Intent.Extras.GetString("returnDate");
            selectedCityId = Intent.Extras.GetInt("cityId");

            cityTextView.Text = selectedCity;
            dateTextView.Text = $"{departureDate} - {returnDate}";

            SetActionBar(tripDetailsToolbar);
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
