
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
            newPlaceToolbar = FindViewById<Toolbar>(Resource.Id.newPlaceToolbar);

            selectedCity = Intent.Extras.GetString("city");
            selectedCityId = Intent.Extras.GetInt("xityId");
                                 

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

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, listVenues);
            venuesListView.Adapter = listAdapter;
        }

        void FilterEditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            var filteredList = listVenues.Where(v => v.name.ToLower().Contains(filterEditText.Text.ToLower())).ToList();

            var listAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, filteredList);
            venuesListView.Adapter = listAdapter;
        }

    }
}
