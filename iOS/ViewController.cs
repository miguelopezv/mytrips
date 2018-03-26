using System;
using MyTrips.Classes;
using UIKit;

namespace MyTrips.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            loginButton.TouchUpInside += LoginButton_TouchUpInside;
        }

        void LoginButton_TouchUpInside(object sender, EventArgs e)
        {
            if (LoginClass.onLogin(usernameTextField.Text, passwordTextField.Text))
            {

            } else {
                //TODO: Navigate to next page
            }
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
