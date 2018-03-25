using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace MyTrips.Droid
{
    [Activity(Label = "MyTrips", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText usernameEditText, passwordEditText;
        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            usernameEditText.FindViewById<EditText>(Resource.Id.usernameEditText);
            passwordEditText.FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton.FindViewById<Button>(Resource.Id.loginButton);
           
            loginButton.Click += onClickLogin;
        }

        private void onClickLogin(object sender, EventArgs args) { 
            if (string.IsNullOrEmpty(usernameEditText.Text) || string.IsNullOrEmpty(passwordEditText.Text))
            {

            } else {
                //TODO: Go to main page
            }
        }
    }
}

