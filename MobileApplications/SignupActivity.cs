using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MobileApplications
{
    [Activity(Label = "Signup", Theme = "@style/AppTheme.NoActionBar")]
    public class SignupActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.signup_page);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 27, 49, 71));

            Button signupButton = FindViewById<Button>(Resource.Id.SignupButton);

            signupButton.Click += SignUpOnClick;
        }

        private void SignUpOnClick(object sender, EventArgs e)
        {
            EditText Nickname = FindViewById<EditText>(Resource.Id.SignupNicknameTxt);
            EditText Password = FindViewById<EditText>(Resource.Id.SignupPasswordTxt);
            string nickname = Nickname.Text;
            string password = Password.Text;
            BLL.GestioneUsers.SignInUser(nickname, password);

            StartActivity(typeof(MainActivity));

        }

    }
}