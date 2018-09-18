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
using Java.Lang;
using Org.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;

namespace MobileApplications
{
    [Activity(Label = "SUOMI", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class FirstPageActivity : AppCompatActivity, IFacebookCallback
    {
        private ICallbackManager CallbackManager;
        private LoginButton FacebookButton;
        private Button loginButton;
        private Button signupButton;
        private ProgressBar FacebookProgressBar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.first_page);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += GoToLoginPage;
            signupButton = FindViewById<Button>(Resource.Id.SignupButton);
            signupButton.Click += GoToSignupPage;

            FacebookButton = FindViewById<LoginButton>(Resource.Id.FacebookLoginButton);
            CallbackManager = CallbackManagerFactory.Create();
            FacebookButton.RegisterCallback(CallbackManager, this);

            FacebookProgressBar = FindViewById<ProgressBar>(Resource.Id.indeterminateBar);
            FacebookProgressBar.Visibility = ViewStates.Invisible;
        }

        private void GoToLoginPage(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
        }

        private void GoToSignupPage(object sender, EventArgs e)
        {
            StartActivity(typeof(SignupActivity));
        }

        public void OnCancel()
        {
            //throw new NotImplementedException();
        }

        public void OnError(FacebookException error)
        {
            //throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            FacebookProgressBar.Visibility = ViewStates.Visible;
            FacebookButton.Enabled = false;
            loginButton.Enabled = false;
            signupButton.Enabled = false;
            LoginResult loginResult = result as LoginResult;
            GraphCallback graphCallBack = new GraphCallback();
            graphCallBack.RequestCompleted += OnGetNameResponse;
            Bundle parameters = new Bundle();
            parameters.PutString("fields", "id,name,email");
            var request = new GraphRequest(loginResult.AccessToken, "/" + loginResult.AccessToken.UserId, parameters, HttpMethod.Get, graphCallBack).ExecuteAsync();
        }

        private void OnGetNameResponse(object sender, GraphResponseEventArgs e)
        {
            
            JSONObject jSON = e.Response.JSONObject;
            if (jSON != null)
            {
                try
                {
                    string id = jSON.GetString("id");
                    string nome = jSON.GetString("name");
                    
                    
                    BE.User utente = BLL.GestioneUsers.ReadFacebookUser(id);
                    if (utente == null)
                    {
                        Intent intent = new Intent(BaseContext, typeof(SignupFacebookActivity));
                        intent.PutExtra("FacebookName", nome);
                        intent.PutExtra("FacebookID", id);
                        FacebookProgressBar.Visibility = ViewStates.Gone;
                        StartActivity(intent);
                    } else
                    {
                        BLL.GestioneUsers.LoginFacebookUser(id);
                        FacebookProgressBar.Visibility = ViewStates.Gone;
                        StartActivity(typeof(MainActivity));
                    }
                } catch { }
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
        
    }

    class GraphCallback : Java.Lang.Object, GraphRequest.ICallback
    {
        // Event to pass the response when it's completed
        public event EventHandler<GraphResponseEventArgs> RequestCompleted = delegate { };

        public void OnCompleted(GraphResponse reponse)
        {
            this.RequestCompleted(this, new GraphResponseEventArgs(reponse));
        }
    }

    public class GraphResponseEventArgs : EventArgs
    {
        GraphResponse _response;
        public GraphResponseEventArgs(GraphResponse response)
        {
            _response = response;
        }

        public GraphResponse Response { get { return _response; } }
    }
}