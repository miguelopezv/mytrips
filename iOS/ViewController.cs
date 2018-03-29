using System;
using Foundation;
using MyTrips.Classes;
using UIKit;

namespace MyTrips.iOS
{
    public partial class ViewController : UIViewController
    {
        bool canNavigate = false;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            loginButton.TouchDown += LoginButton_TouchDown;

            NavigationController.SetNavigationBarHidden(true, false);
        }

        void LoginButton_TouchDown(object sender, EventArgs e)
        {
            if (LoginClass.onLogin(usernameTextField.Text, passwordTextField.Text))
            {
                canNavigate = true;
            }
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }

		public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
		{
            if (segueIdentifier == "goToMainPageSegue")
            {
                if(canNavigate)
                {
                    return true;  
                }
            } else {
                return false;
            }
            return false;
		}
	}
}
