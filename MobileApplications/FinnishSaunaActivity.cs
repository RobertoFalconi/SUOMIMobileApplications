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

using static BLL.GestioneFinnishSaunas;

namespace MobileApplications
{    

    [Activity(Label = "Finnish Sauna", Theme = "@style/AppTheme.NoActionBar")]
    public class FinnishSaunaActivity : AppCompatActivity
    {
        TextView UsersList { get; set; }
        Button EnqueueButton { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.new_page);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 23, 114, 176));

            
            UsersList = FindViewById<TextView>(Resource.Id.FinnishSaunaText);
            RefreshFinnishSaunaList();

            EnqueueButton = FindViewById<Button>(Resource.Id.EnqueueInSauna);
            if (!ControllaUtente(BE.User.CurrentUser))
            {
                EnqueueButton.Text = "Add to queue!";
            } else
            {
                EnqueueButton.Text = "Delete from queue!";
            }
            
            EnqueueButton.Click += EnqueueOnClick;

        }

        private void EnqueueOnClick(object sender, EventArgs e)
        {
            if (!ControllaUtente(BE.User.CurrentUser))
            {
                EnqueueInFinnishSauna(BE.User.CurrentUser);
                Toast.MakeText(this, "You're now enqueued for the finnish sauna!", ToastLength.Long).Show();
                EnqueueButton.Text = "Delete from queue!";
            } else
            {
                DequeueFromFinnishSauna(BE.User.CurrentUser);
                Toast.MakeText(this, "You've deleted your reservation for the finnish sauna!", ToastLength.Long).Show();
                EnqueueButton.Text = "Add to queue!";
            }
            RefreshFinnishSaunaList();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home) Finish();
            return base.OnOptionsItemSelected(item);
        }

        private void RefreshFinnishSaunaList()
        {
            string list = "";
            if (IsFinnishSaunaEmpty())
            {
                list = "No one is enqueued. Be the first!";
            }
            else
            {
                int i = 1;
                ReadFinnishSauna().ForEach(x =>
                {
                    list += String.Format("{0}. {1}\n", i, x);
                    i++;
                });
            }
            UsersList.Text = list;
        }
    }
}