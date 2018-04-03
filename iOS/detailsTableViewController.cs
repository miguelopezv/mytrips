using Foundation;
using MyTrips.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using UIKit;

namespace MyTrips.iOS
{
    public partial class detailsTableViewController : UITableViewController
    {
        public string selectedCity;
        public int selectedCityId;

        List<InterestSite> places;

        public detailsTableViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            NavigationItem.Title = selectedCity;
            places = new List<InterestSite>();
		}

		public override void ViewDidAppear(bool animated)
		{
            base.ViewDidAppear(animated);

            string fileName = "trips_db.sqlite";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(filePath, fileName);

            places = DbHelper.returnInterestSite(selectedCityId, fullPath);
            TableView.ReloadData();
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return places.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            var cell = tableView.DequeueReusableCell("interestSiteIdentifier", indexPath);
            var data = places[indexPath.Row];
            cell.TextLabel.Text = data.Name;
            cell.DetailTextLabel.Text = data.Category;

			return cell;
		}
	}
}