
using System;
using System.IO;

using Android.App;
using Android.OS;
using Android.Widget;
using MyTrips.Classes;

namespace MyTrips.Droid
{
    [Activity(Label = "NewTripActivity")]
    public class NewTripActivity : Activity
    {
        EditText placeEditText;
        DatePicker departureDatePicker, returnDatePicker;
        Button saveButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewTrip);

            placeEditText = FindViewById<EditText>(Resource.Id.placeEditText);
            departureDatePicker = FindViewById<DatePicker>(Resource.Id.departureDatePicker);
            returnDatePicker = FindViewById<DatePicker>(Resource.Id.returnDatePicker);
            saveButton = FindViewById<Button>(Resource.Id.saveButton);

            saveButton.Click += SaveButton_Click;
        }

        void SaveButton_Click(object sender, EventArgs e)
        {
            string fileName = "trips_db.sqlite";
            string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(filePath, fileName);

            var newTrip = new Trip()
            {
                Place = placeEditText.Text,
                DepartureDate = departureDatePicker.DateTime,
                ReturnDate = returnDatePicker.DateTime
            };

            if (DbHelper.insert<Trip>(ref newTrip, path)) {
                Toast.MakeText(this, "Trip Added!", ToastLength.Short).Show();
            } else {
                Toast.MakeText(this, "There was an error. Try again.", ToastLength.Short).Show();
            };
        }

    }
}
