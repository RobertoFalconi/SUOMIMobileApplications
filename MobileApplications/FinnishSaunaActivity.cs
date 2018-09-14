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
using BLL;

namespace MobileApplications
{    

    [Activity(Label = "Finnish Sauna", Theme = "@style/AppTheme.NoActionBar")]
    public class FinnishSaunaActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.new_page);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 27, 49, 71));

            
            TextView welcome = FindViewById<TextView>(Resource.Id.FinnishSaunaText);
            string lista = "";
            GestioneFinnishSaunas.ReadFinnishSauna().ForEach(x => lista += x + " ");
            welcome.Text = lista;

            Button enqueueButton = FindViewById<Button>(Resource.Id.EnqueueInSauna);
            if (!GestioneFinnishSaunas.ControllaUtente(BE.User.CurrentUser))
            {
                enqueueButton.Text = "Add to queue!";
            } else
            {
                enqueueButton.Text = "Delete from queue!";
            }
            
            enqueueButton.Click += EnqueueOnClick;

        }

        private void EnqueueOnClick(object sender, EventArgs e)
        {
            if (!GestioneFinnishSaunas.ControllaUtente(BE.User.CurrentUser))
            {
                GestioneFinnishSaunas.EnqueueInFinnishSauna(BE.User.CurrentUser);
            } else
            {
                GestioneFinnishSaunas.DequeueFromFinnishSauna(BE.User.CurrentUser);
            }
            
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}