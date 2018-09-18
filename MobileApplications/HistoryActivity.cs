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
    [Activity(Label = "Reservations", Theme = "@style/AppTheme.NoActionBar")]
    public class HistoryActivity : AppCompatActivity
    {
        TextView Reservation1 { get; set; }
        TextView Reservation2 { get; set; }
        TextView Reservation3 { get; set; }
        TextView Reservation4 { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.reservations);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 23, 114, 176));

            Reservation1 = FindViewById<TextView>(Resource.Id.Reservation1);
            Reservation2 = FindViewById<TextView>(Resource.Id.Reservation2);
            Reservation3 = FindViewById<TextView>(Resource.Id.Reservation3);
            Reservation4 = FindViewById<TextView>(Resource.Id.Reservation4);

            CheckReservations();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) Finish();
            return base.OnOptionsItemSelected(item);
        }

        private void CheckReservations()
        {
            if (BLL.GestioneFinnishSaunas.ControllaUtente(BE.User.CurrentUser))
            {
                List<string> finnishSaunaUsers = BLL.GestioneFinnishSaunas.ReadFinnishSauna();
                int index = finnishSaunaUsers.FindIndex(x => x == BE.User.CurrentUser.Nickname);
                if (index > 0)
                {
                    string people = index == 1 ? "person" : "people";
                    Reservation1.Text = String.Format("You have {0} {1} before you.", index, people);
                }
                else if (index == 0)
                {
                    Reservation1.Text = "It's your turn!";
                }
            }
            if (BLL.GestioneTurkishBaths.ControllaUtente(BE.User.CurrentUser))
            {
                List<string> turkishBathUsers = BLL.GestioneTurkishBaths.ReadTurkishBath();
                int index = turkishBathUsers.FindIndex(x => x == BE.User.CurrentUser.Nickname);
                if (index > 0)
                {
                    string people = index == 1 ? "person" : "people";
                    Reservation2.Text = String.Format("You have {0} {1} before you.", index, people);
                }
                else if (index == 0)
                {
                    Reservation2.Text = "It's your turn!";
                }
            }
            if (BLL.GestioneKneipps.ControllaUtente(BE.User.CurrentUser))
            {
                List<string> kneippUsers = BLL.GestioneKneipps.ReadKneipp();
                int index = kneippUsers.FindIndex(x => x == BE.User.CurrentUser.Nickname);
                if (index > 0)
                {
                    string people = index == 1 ? "person" : "people";
                    Reservation3.Text = String.Format("You have {0} {1} before you.", index, people);
                }
                else if (index == 0)
                {
                    Reservation3.Text = "It's your turn!";
                }
            }
            if (BLL.GestioneJacuzzis.ControllaUtente(BE.User.CurrentUser))
            {
                List<string> jacuzziUsers = BLL.GestioneJacuzzis.ReadJacuzzi();
                int index = jacuzziUsers.FindIndex(x => x == BE.User.CurrentUser.Nickname);
                if (index > 0)
                {
                    string people = index == 1 ? "person" : "people";
                    Reservation4.Text = String.Format("You have {0} {1} before you.", index, people);
                } else if (index == 0)
                {
                    Reservation4.Text = "It's your turn!";
                }
            }

        }

    }
}