using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

namespace MobileApplications
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener, ILocationListener
    {
        Location currentLocation;
        LocationManager locationManager;
        string locationProvider;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);

            TextView welcome = FindViewById<TextView>(Resource.Id.WelcomeUser);
            welcome.Text = "Welcome, " + BE.User.CurrentUser.Nickname + "!";

            InitializeLocationManager();
        }

        private void InitializeLocationManager()
        {
            locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = locationManager.GetProviders(criteriaForLocationService, true);
            if (acceptableLocationProviders.Any())
            {
                locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                locationProvider = string.Empty;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            TextView welcome = FindViewById<TextView>(Resource.Id.WelcomeUser);
            welcome.Text = "Welcome, " + BE.User.CurrentUser.Nickname + "!";
        }

        protected override void OnResume()
        {
            base.OnResume();
            try
            {
                locationManager.RequestLocationUpdates(locationProvider, 0, 0, this);
            }
            catch { }

        }
        protected override void OnPause()
        {
            base.OnPause();
            locationManager.RemoveUpdates(this);
        }

        private void RedirectToLoginOnClick(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if (drawer.IsDrawerOpen(GravityCompat.Start))
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
                StartActivity(typeof(ProfileActivity));
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            //View view = (View)sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            StartActivity(typeof(HistoryActivity));
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id == Resource.Id.FinnishSauna)
            {
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
            else if (id == Resource.Id.logout_button)
            {
                BLL.GestioneUsers.LogoutUser(BE.User.CurrentUser);
                if (AccessToken.CurrentAccessToken != null)
                {
                    LoginManager.Instance.LogOut();
                }
                StartActivity(typeof(FirstPageActivity));
            }

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }

        public async void OnLocationChanged(Location location)
        {
            currentLocation = location;
            if (currentLocation == null)
            {
                //Error Message  
            }
            else
            {
                //TextView locationText = FindViewById<TextView>(Resource.Id.locationTextView);
                string latitude = currentLocation.Latitude.ToString();
                string longitude = currentLocation.Longitude.ToString();
                //locationText.Text = String.Format("Latitude: {0} - Longitude: {1}", latitude, longitude);
                
                Weather weather = await Task.Run(() => Weather(latitude, longitude));

                string weatherCompleteDescription = String.Empty;
                string weatherDesc = weather.ShortDesc;

                switch (weather.Id.First().ToString())
                {
                    case "2":
                    case "3":
                    case "5":
                    case "6":
                        weatherCompleteDescription = "There's a " + weatherDesc + " outside.";
                        break;
                    case "7":
                        weatherCompleteDescription = "There's a " + weatherDesc + " atmosphere.";
                        break;
                    case "8":
                        if (weather.Id == "800")
                        {
                            weatherCompleteDescription = "We have a " + weatherDesc + " today!";
                        }
                        else
                        {
                            weatherCompleteDescription = "The sky is overshadowed by " + weatherDesc + ".";
                        }

                        break;
                }

                TextView weatherText = FindViewById<TextView>(Resource.Id.weatherTextView);
                weatherText.Text = "It's " + weather.Temp + "°C in " + weather.Name + ".";

                TextView weatherDescView = FindViewById<TextView>(Resource.Id.weatherDescTextView);
                weatherDescView.Text = weatherCompleteDescription;

                ImageView weatherImage = FindViewById<ImageView>(Resource.Id.weatherImageView);
                try
                {
                    var imageBitmap = GetBitmapFromUrl("http://openweathermap.org/img/w/" + weather.Icon + ".png");
                    weatherImage.SetImageBitmap(imageBitmap);
                } catch { }

            }
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            // Called when the provider status changes.
            // This method is called when a provider is unable to fetch a location or
            // if the provider has recently become available after a period of unavailability. 
        }

        private async Task<Weather> Weather(string latitude, string longitude)
        {
            Weather weather = new Weather();
            string key = BLL.GestioneWeather.GetWeatherAPIKey();

            string queryString = "http://api.openweathermap.org/data/2.5/weather?lat="
               + latitude + "&lon=" + longitude + "&appid=" + key + "&units=metric";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }

            weather.Temp = data["main"]["temp"];
            weather.Name = data["name"];
            weather.ShortDesc = data["weather"][0]["description"]; ;
            weather.Id = data["weather"][0]["id"];
            weather.Icon = data["weather"][0]["icon"];

            return weather;
        }

        public static Android.Graphics.Bitmap GetBitmapFromUrl(string url)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] bytes = webClient.DownloadData(url);
                if (bytes != null && bytes.Length > 0)
                {
                    return Android.Graphics.BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                }
            }
            return null;
        }
    }
}

