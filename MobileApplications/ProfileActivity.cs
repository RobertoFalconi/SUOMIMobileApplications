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
    [Activity(Label = "Profile Settings", Theme = "@style/AppTheme.NoActionBar")]
    public class ProfileActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.profile_page);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 23, 114, 176));

            EditText oldNickname = FindViewById<EditText>(Resource.Id.ChangeNicknameTxt);
            string userNickname = BE.User.CurrentUser.Nickname;
            oldNickname.Text = userNickname;

            EditText oldPassword = FindViewById<EditText>(Resource.Id.ChangePasswordTxt);
            string userPassword = BE.User.CurrentUser.Password;
            oldPassword.Text = userPassword;

            Button updateButton = FindViewById<Button>(Resource.Id.UpdateButton);
            updateButton.Click += UpdateOnClick;

            Button deleteButton = FindViewById<Button>(Resource.Id.DeleteButton);
            deleteButton.Click += DeleteOnClick;
        }

        protected override void OnStart()
        {
            base.OnStart();
            EditText oldNickname = FindViewById<EditText>(Resource.Id.ChangeNicknameTxt);
            string userNickname = BE.User.CurrentUser.Nickname;
            oldNickname.Text = userNickname;

            EditText oldPassword = FindViewById<EditText>(Resource.Id.ChangePasswordTxt);
            string userPassword = BE.User.CurrentUser.Password;
            oldPassword.Text = userPassword;

            Button updateButton = FindViewById<Button>(Resource.Id.UpdateButton);

            updateButton.Click += UpdateOnClick;
        }

        private void UpdateOnClick(object sender, EventArgs e)
        {
            EditText newNickname = FindViewById<EditText>(Resource.Id.ChangeNicknameTxt);
            EditText newPassword = FindViewById<EditText>(Resource.Id.ChangePasswordTxt);
            string currentNickname = BE.User.CurrentUser.Nickname;

            string nickname = newNickname.Text;
            string password = newPassword.Text;

            // Check nickname
            if (nickname == String.Empty)
            {
                Toast.MakeText(this, "Insert a nickname.", ToastLength.Long).Show();
            }
            // Check password
            if (password == String.Empty)
            {
                Toast.MakeText(this, "Insert a valid password.", ToastLength.Long).Show();
            }

            if (nickname != String.Empty && password != String.Empty)
            {
                // Check nickname existance
                if (!currentNickname.Equals(nickname))
                {
                    if (BLL.GestioneUsers.CheckNickname(nickname))
                    {
                        Toast.MakeText(this, "This nickname already exists. Choose another one.", ToastLength.Long).Show();
                    }
                    else
                    {
                        BLL.GestioneUsers.UpdateUser(BE.User.CurrentUser, nickname, password);
                        Toast.MakeText(this, "Profile updated!", ToastLength.Short).Show();
                    }
                } else
                {
                    BLL.GestioneUsers.UpdateUser(BE.User.CurrentUser, nickname, password);
                    Toast.MakeText(this, "Profile updated!", ToastLength.Short).Show();
                }
            }
        }

        private void DeleteOnClick(object sender, EventArgs e)
        {
            BLL.GestioneUsers.DeleteUser(BE.User.CurrentUser);
            StartActivity(typeof(FirstPageActivity));
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}