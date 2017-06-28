using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoloTravellerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolotravellerMasterDetailPage : MasterDetailPage
    {
        public SolotravellerMasterDetailPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as SolotravellerMasterDetailPageMenuItem;
            if (item == null)
                return;
            if(item.TargetType == typeof(LogoutPage))
            {
                App.Store.Delete(App.Account, Constants.AppName);
                App.Current.MainPage = new LoginPage();
                return;
            }
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}