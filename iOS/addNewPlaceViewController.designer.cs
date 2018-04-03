// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MyTrips.iOS
{
    [Register ("addNewPlaceViewController")]
    partial class addNewPlaceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView categoriesPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField filterTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView placesTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem saveNewBarButton { get; set; }

        [Action ("SaveNew_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveNew_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (categoriesPickerView != null) {
                categoriesPickerView.Dispose ();
                categoriesPickerView = null;
            }

            if (filterTextField != null) {
                filterTextField.Dispose ();
                filterTextField = null;
            }

            if (placesTableView != null) {
                placesTableView.Dispose ();
                placesTableView = null;
            }

            if (saveNewBarButton != null) {
                saveNewBarButton.Dispose ();
                saveNewBarButton = null;
            }
        }
    }
}