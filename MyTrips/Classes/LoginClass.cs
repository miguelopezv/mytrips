using System;
namespace MyTrips.Classes
{
    public class LoginClass
    {
        public LoginClass()
        {
        }

        public static bool onLogin(string user, string password) { 
            return !string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password);
            //TODO: real validation for user
        }

    }
}
