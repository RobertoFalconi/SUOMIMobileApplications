using System;
using System.Collections.Generic;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace MobileApplications
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        static Random rnd = new Random();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            //Button button = FindViewById<Button>(Resource.Id.TestButton);
            //button.Click += TestOnClick;

            //Button loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            //loginButton.Click += RedirectToLoginOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            TextView welcome = FindViewById<TextView>(Resource.Id.WelcomeUser);
            string userNickname = Intent.GetStringExtra("UtenteCorrente");
            welcome.Text = "Welcome " + userNickname;
        }

        //private void TestOnClick(object sender, EventArgs e)
        //{
        //    TextView test = FindViewById<TextView>(Resource.Id.TestText);
        //    List<string> tests = new List<string>() { "Test 1", "Test 2", "Test 3", "Test 4", "Test 5" };
        //    test.Text = tests[rnd.Next(tests.Count)];
        //}

        private void RedirectToLoginOnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.FinnishSauna)
            {
                // Handle the FinnishSauna action
                // var intent = new Intent(this, typeof(NewPageActivity));
                StartActivity(typeof(FinnishSaunaActivity));
            }
            else if (id == Resource.Id.TurkishBath)
            {
                StartActivity(typeof(TurkishBathsActivity));
            }
            else if (id == Resource.Id.Kneipp)
            {
                StartActivity(typeof(KneippsActivity));
            }
            else if (id == Resource.Id.Jacuzzi)
            {
                StartActivity(typeof(JacuzzisActivity));
            }
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.logout_button)
            {
                BLL.GestioneUsers.LogoutUser(BE.User.CurrentUser);
                StartActivity(typeof(FirstPageActivity));
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }
    }
}

