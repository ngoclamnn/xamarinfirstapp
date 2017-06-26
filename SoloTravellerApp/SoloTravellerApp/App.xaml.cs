using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;

namespace SoloTravellerApp
{
    public partial class App : Application
    {
        public static Account Account;
        public static AccountStore Store;

        public App()
        {
            InitializeComponent();
            Store = AccountStore.Create();
            Account = Store.FindAccountsForService(Constants.AppName).FirstOrDefault();
            if (Account != null)
                MainPage = new NavigationPage(new MainPage());
            else
                MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
