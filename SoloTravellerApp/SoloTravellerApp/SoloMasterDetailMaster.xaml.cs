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
    public partial class SoloMasterDetailMaster : ContentPage
    {
        public ListView ListView;

        public SoloMasterDetailMaster()
        {
            InitializeComponent();

            BindingContext = new SoloMasterDetailMasterViewModel();
            ListView = MenuItemsListView;
        }

        class SoloMasterDetailMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SoloMasterDetailMenuItem> MenuItems { get; set; }

            public SoloMasterDetailMasterViewModel()
            {
                MenuItems = new ObservableCollection<SoloMasterDetailMenuItem>(new[]
                {
                    new SoloMasterDetailMenuItem { Id = 0, Title = "Page 1" },
                    new SoloMasterDetailMenuItem { Id = 1, Title = "Page 2" },
                    new SoloMasterDetailMenuItem { Id = 2, Title = "Page 3" },
                    new SoloMasterDetailMenuItem { Id = 3, Title = "Page 4" },
                    new SoloMasterDetailMenuItem { Id = 4, Title = "Page 5" },
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