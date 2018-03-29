using Android.App;
using Android.Widget;
using Android.OS;
using System;
using MyTrips.Classes;
using Android.Content;

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

            usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
           
            loginButton.Click += onClickLogin;
        }

        private void onClickLogin(object sender, EventArgs args) { 
            if (LoginClass.onLogin(usernameEditText.Text, passwordEditText.Text))
            {
                Intent intent = new Intent(this, typeof(ListTripsActivity));
                StartActivity(intent);
            }
        }
    }
}

