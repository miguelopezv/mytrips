
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
using MyTrips.Classes.Helpers;

namespace MyTrips.Droid
{
    [Activity(Label = "NewPlaceActivity")]
    public class NewPlaceActivity : Activity
    {
        EditText filterEditText;
        Spinner categoriesSpinner;
        ListView venuesListView;
        Toolbar newPlaceToolbar;

        List<Categories.Category> listCategories;
        List<Venue> listVenues;

        string selectedCity;
        int selectedCityId;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewPlace);

            filterEditText = FindViewById<EditText>(Resource.Id.filterEditText);
            categoriesSpinner = FindViewById<Spinner>(Resource.Id.categoriesSpinner);
            venuesListView = FindViewById<ListView>(Resource.Id.venuesListView);
            venuesListView.ChoiceMode = ChoiceMode.Multiple;
            newPlaceToolbar = FindViewById<Toolbar>(Resource.Id.newPlaceToolbar);

            SetActionBar(newPlaceToolbar);
            ActionBar.Title = "Add new venue";

            selectedCity = Intent.Extras.GetString("city");
            selectedCityId = Intent.Extras.GetInt("cityId");

                             
            Foursquare foursquareHelper = new Foursquare();
            listCategories = await foursquareHelper.getCategories();

            var spinnerAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, listCategories);
            categoriesSpinner.Adapter = spinnerAdapter;

            categoriesSpinner.ItemSelected += CategoriesSpinner_ItemSelected;

            filterEditText.TextChanged += FilterEditText_TextChanged;
        }

        async void CategoriesSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var selectedCategory = listCategories[e.Position];

            Foursquare foursquareHelper = new Foursquare();
            listVenues = await foursquareHelper.getVenues(selectedCity, selectedCategory.id);

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, listVenues);
            venuesListView.Adapter = listAdapter;
        }

        void FilterEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var filteredList = listVenues.Where(v => v.name.ToLower().Contains(filterEditText.Text.ToLower())).ToList();

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, filteredList);
            venuesListView.Adapter = listAdapter;
        }

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.Save, menu);

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
            string fileName = "trips_db.sqlite";
            string filePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullPath = Path.Combine(filePath, fileName);

            if(item.TitleFormatted.ToString() == "Save")
            {
                var selectedPositions = venuesListView.CheckedItemPositions;

                for (int i = 0; i < selectedPositions.Size(); i++)
                {
                    if(selectedPositions.ValueAt(i))
                    {
                        var cellText = venuesListView.Adapter.GetItem(selectedPositions.KeyAt(i)).ToString();
                        var selectedVenue = listVenues.Where(v => cellText.Contains(v.name)).First();

                        InterestSite interestSite = new InterestSite(selectedVenue, selectedCityId);
                        if(DbHelper.insert(ref interestSite, fullPath))
                        {
                            Toast.MakeText(this, "Added Item", ToastLength.Long).Show();
                        }
                    }
                }
            }

            return base.OnOptionsItemSelected(item);
		}

	}
}
