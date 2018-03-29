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
    [Register ("ListTripsViewController")]
    partial class ListTripsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem addItemButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (addItemButton != null) {
                addItemButton.Dispose ();
                addItemButton = null;
            }
        }
    }
}