using Foundation;
using MyTrips.Classes;
using System;
using System.IO;
using UIKit;
using GlobalToast;

namespace MyTrips.iOS
{
    public partial class NewTripViewController : UIViewController
    {
        public NewTripViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            saveBarButton.Clicked += SaveBarButton_Clicked;
		}

        void SaveBarButton_Clicked(object sender, EventArgs e)
        {
            string fileName = "trips_db.sqlite";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(filePath, fileName);

            var newTrip = new Trip()
            {
                Place = placeTextField.Text,
                DepartureDate = (DateTime)departureDatePicker.Date,
                ReturnDate = (DateTime)returnDatePicker.Date

            };

            if(DbHelper.insert<Trip>(ref newTrip, fullPath))
            {
                NavigationController.PopViewController(true);
            } else {
                Toast.ShowToast("There was an error, try again");
                Console.WriteLine("Error");
            }
        }
    }
}