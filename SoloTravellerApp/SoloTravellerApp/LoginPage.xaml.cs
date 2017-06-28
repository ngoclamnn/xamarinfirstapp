using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoloTravellerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }
        void OnLoginClicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;
            switch (Device.RuntimePlatform)
            {
                //case Device.iOS:
                //    clientId = Constants.iOSClientId;
                //    redirectUri = Constants.iOSRedirectUrl;
                //    break;
                case Device.Android:
                    clientId = Constants.AndroidClientId;
                    redirectUri = Constants.AndroidRedirectUrl;
                    break;
            }
            var authenticator = new OAuth2Authenticator(
                clientId,
                "",
                new Uri(Constants.AuthorizeUrl),
                new Uri(redirectUri), null,
                false);
            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;
            AuthenticationState.Authenticator = authenticator;
            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
       
        }
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }
            User user = null;
            if (e.IsAuthenticated)
            {
                if (App.Account != null)
                {
                    App.Store.Delete(App.Account, Constants.AppName);
                }
                await App.Store.SaveAsync(App.Account = e.Account, Constants.AppName);
                App.Current.MainPage = new SolotravellerMasterDetailPage();
            }
        }
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }
            Debug.WriteLine("Authentication error: " + e.Message);

        }

    }
}
