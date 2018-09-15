using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MobileApplications
{
    [Activity(Label = "SUOMI", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class FirstPageActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.first_page);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            Button loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += GoToLoginPage;
            Button signupButton = FindViewById<Button>(Resource.Id.SignupButton);
            signupButton.Click += GoToSignupPage;
        }

        private void GoToLoginPage(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

        private void GoToSignupPage(object sender, EventArgs e)
        {
            StartActivity(typeof(SignupActivity));
        }
    }
}