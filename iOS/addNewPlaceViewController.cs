using Foundation;
using MyTrips.Classes;
using MyTrips.Classes.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UIKit;

namespace MyTrips.iOS
{
    public partial class addNewPlaceViewController : UIViewController
    {
        List<Categories.Category> categories;
        List<Venue> venues;
        public string selectedCity;
        public int selectedCityId;

        public addNewPlaceViewController (IntPtr handle) : base (handle)
        {
            
        }

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

            placesTableView.AllowsMultipleSelection = true;

            Foursquare helper = new Foursquare();
            categories = await helper.getCategories();

            var model = new CategoriesPickerViewModel(categories);
            model.selected_Category += Model_Selected_Category;
            categoriesPickerView.Model = model;

            saveNewBarButton.Clicked += SaveNewBarButton_Clicked;

            var category = model.idSelectedCategory;
            venues = await helper.getVenues(selectedCity, category);

            var tableSource = new TableSource(venues);
            placesTableView.Source = tableSource;
            placesTableView.ReloadData();

            filterTextField.EditingChanged += FilterTextField_EditingChanged;
		}

        async void Model_Selected_Category(object sender, EventArgs e)
        {
            var category = (sender as CategoriesPickerViewModel).idSelectedCategory;

            Foursquare helper = new Foursquare();
            venues = await helper.getVenues(selectedCity, category);

            var tableSource = new TableSource(venues);
            placesTableView.Source = tableSource;
            placesTableView.ReloadData();
        }

        void SaveNewBarButton_Clicked(object sender, EventArgs e)
        {
            string fileName = "trips_db.sqlite";
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
            string fullPath = Path.Combine(filePath, fileName);

            var selectedItems = placesTableView.IndexPathsForSelectedRows;

            foreach (var item in selectedItems)
            {
                var cellText = placesTableView.CellAt(item).TextLabel.Text;
                var selectedVenue = venues.Where(v => v.name.Contains(cellText)).FirstOrDefault();

                InterestSite interestSite = new InterestSite(selectedVenue, selectedCityId);

                DbHelper.insert(ref interestSite, fullPath);
            }

            NavigationController.PopViewController(true);
        }

        void FilterTextField_EditingChanged(object sender, EventArgs e)
        {
            var filteredVenues = venues.Where(v => v.name.ToLower().Contains(filterTextField.Text.ToLower())).ToList();

            var tableSource = new TableSource(filteredVenues);
            placesTableView.Source = tableSource;
            placesTableView.ReloadData();
        }

    }

    public class CategoriesPickerViewModel : UIPickerViewModel
    {
        List<Categories.Category> categories;
        public string idSelectedCategory
        {
            get;
            set;
        }

        public event EventHandler selected_Category;


        public CategoriesPickerViewModel(List<Categories.Category> categories)
        {
            this.categories = categories;
            idSelectedCategory = categories[0].id;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return categories.Count;
		}

		public override nint GetComponentCount(UIPickerView pickerView)
		{
            return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return categories[(int)row].name;
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
            idSelectedCategory = categories[(int)row].id;
            selected_Category(this, null);
		}
	}

    public class TableSource : UITableViewSource
    {
        public TableSource(List<Venue> places)
        {
            this.places = places;
        }

        List<Venue> places;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("venueCellIdentifier");
            var data = places[indexPath.Row];

            cell.TextLabel.Text = data.name;
            cell.DetailTextLabel.Text = data.categories.FirstOrDefault().name;

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return places.Count;
        }
    }
}