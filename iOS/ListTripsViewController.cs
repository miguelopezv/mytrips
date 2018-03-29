using Foundation;
using MyTrips.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;

namespace MyTrips.iOS
{
    public partial class ListTripsViewController : UITableViewController
    {
        List<Trip> ListTrips;

        public ListTripsViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ListTrips = new List<Trip>();

            NavigationItem.SetHidesBackButton(true, false);
            NavigationController.SetNavigationBarHidden(false, true);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            //TODO: Create constants for DB on iOS and Android
            string fileName = "trips_db.sqlite";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(filePath, fileName);

            ListTrips = DbHelper.returnTrips(fullPath);

            TableView.ReloadData();

        }

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var cell = tableView.DequeueReusableCell("tripReuseIdentifier", indexPath);
            var data = ListTrips[indexPath.Row];

            cell.TextLabel.Text = data.Place;
            cell.DetailTextLabel.Text = $"{data.DepartureDate:d} - {data.ReturnDate:d}";


			return cell;
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return ListTrips.Count;
		}	
	}
}