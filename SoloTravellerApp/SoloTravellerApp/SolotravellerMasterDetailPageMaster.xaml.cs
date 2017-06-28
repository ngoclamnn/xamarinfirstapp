using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SoloTravellerApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SolotravellerMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public SolotravellerMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new SolotravellerMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SolotravellerMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SolotravellerMasterDetailPageMenuItem> MenuItems { get; set; }

            public SolotravellerMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<SolotravellerMasterDetailPageMenuItem>(new[]
                {
                    new SolotravellerMasterDetailPageMenuItem { Id = 0, Title = "Contacts", TargetType = typeof(ContactsPage) },
                    new SolotravellerMasterDetailPageMenuItem { Id = 1, Title = "To do list", TargetType = typeof(ToDoListPage) },
                    new SolotravellerMasterDetailPageMenuItem { Id = 2, Title = "Reminder", TargetType = typeof(ReminderPage) },
                    new SolotravellerMasterDetailPageMenuItem { Id = 3, Title = "Maps", TargetType = typeof(MapPage) },
                    new SolotravellerMasterDetailPageMenuItem { Id = 4, Title = "Logout", TargetType = typeof(LogoutPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}