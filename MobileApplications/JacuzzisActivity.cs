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
    [Activity(Label = "Jacuzzis", Theme = "@style/AppTheme.NoActionBar")]
    public class JacuzzisActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.jacuzzis);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 27, 49, 71));

            TextView welcome = FindViewById<TextView>(Resource.Id.JacuzziText);
            string lista = "";
            BLL.GestioneJacuzzis.ReadJacuzzi().ForEach(x => lista += x + " ");
            welcome.Text = lista;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}