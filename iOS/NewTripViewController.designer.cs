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
    [Register ("NewTripViewController")]
    partial class NewTripViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker departureDatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField placeTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker returnDatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem saveBarButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (departureDatePicker != null) {
                departureDatePicker.Dispose ();
                departureDatePicker = null;
            }

            if (placeTextField != null) {
                placeTextField.Dispose ();
                placeTextField = null;
            }

            if (returnDatePicker != null) {
                returnDatePicker.Dispose ();
                returnDatePicker = null;
            }

            if (saveBarButton != null) {
                saveBarButton.Dispose ();
                saveBarButton = null;
            }
        }
    }
}