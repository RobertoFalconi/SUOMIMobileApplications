﻿using System;
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
    [Activity(Label = "Facebook Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class SignupFacebookActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.signup_facebook_page);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 23, 114, 176));

            EditText Nickname = FindViewById<EditText>(Resource.Id.SignupNicknameTxt);
            Nickname.RequestFocus();

            Button signupButton = FindViewById<Button>(Resource.Id.SignupButton);

            signupButton.Click += SignUpOnClick;

            string facebookName = Intent.GetStringExtra("FacebookName");
            TextView facebookLabel = FindViewById<TextView>(Resource.Id.FacebookNameLabel);
            facebookLabel.Text = "Welcome aboard, " + facebookName + "!";
        }

        private void SignUpOnClick(object sender, EventArgs e)
        {
            EditText Nickname = FindViewById<EditText>(Resource.Id.SignupNicknameTxt);
            EditText Password = FindViewById<EditText>(Resource.Id.SignupPasswordTxt);
            string nickname = Nickname.Text;
            string password = Password.Text;
            string facebookID = Intent.GetStringExtra("FacebookID");

            // Check nickname
            if (nickname == String.Empty)
            {
                Toast.MakeText(this, "Insert a nickname.", ToastLength.Long).Show();
            }
            // Check password
            if (password == String.Empty)
            {
                Toast.MakeText(this, "Insert a password.", ToastLength.Long).Show();
            }

            if (nickname != String.Empty && password != String.Empty)
            {
                // Check nickname existance
                if (BLL.GestioneUsers.CheckNickname(nickname))
                {
                    Toast.MakeText(this, "This nickname already exists. Choose another one.", ToastLength.Long).Show();
                }
                else
                {
                    BLL.GestioneUsers.SigninFacebookUser(nickname, password, facebookID);
                    StartActivity(typeof(MainActivity));
                }
            }
        }
    }
}