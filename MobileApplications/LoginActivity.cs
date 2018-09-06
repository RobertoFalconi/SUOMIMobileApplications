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
using BE;

namespace MobileApplications
{
    [Activity(Label = "Login", Theme = "@style/AppTheme.NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_page);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 27, 49, 71));

            Button loginButton = FindViewById<Button>(Resource.Id.LoginButton);

            loginButton.Click += LoginOnClick;
        }

        private void LoginOnClick(object sender, EventArgs e)
        {
            EditText Nickname = FindViewById<EditText>(Resource.Id.LoginNicknameTxt);
            EditText Password = FindViewById<EditText>(Resource.Id.LoginPasswordTxt);
            string nickname = Nickname.Text;
            string password = Password.Text;
            User utenteCorrente = BLL.GestioneUsers.LoginUser(nickname, password);
            Intent utenteCorrenteIntent = new Intent(BaseContext, typeof(MainActivity));
            utenteCorrenteIntent.PutExtra("UtenteCorrente", utenteCorrente.Nickname);
            StartActivity(utenteCorrenteIntent);

        }
    }
}