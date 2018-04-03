using Foundation;
using MapKit;
using MyTrips.Classes;
using System;
using System.Collections.Generic;
using UIKit;

namespace MyTrips.iOS
{
    public partial class PlaceMapViewController : UIViewController
    {
        public List<InterestSite> places;

        public PlaceMapViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            foreach (var place in places)
            {
                venueMapView.AddAnnotation(new MKPointAnnotation()
                {
                    Title = place.Name,
                    Coordinate = new CoreLocation.CLLocationCoordinate2D(place.Lat, place.Lng)
                });
            }
        }
    }
}