using Foundation;
using MyTrips.Classes;
using MyTrips.Classes.Helpers;
using System;
using System.Collections.Generic;
using UIKit;

namespace MyTrips.iOS
{
    public partial class addNewPlaceViewController : UIViewController
    {
        List<Categories.Category> categories;

        public addNewPlaceViewController (IntPtr handle) : base (handle)
        {
            
        }

		public override async void ViewDidLoad()
		{
			base.ViewDidLoad();

            Foursquare helper = new Foursquare();
            categories = await helper.getCategories();

            var model = new CategoriesPickerViewModel(categories);
            model.selected_Category += Model_Selected_Category;
            categoriesPickerView.Model = model;
		}

        void Model_Selected_Category(object sender, EventArgs e)
        {
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
}