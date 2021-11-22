using Navigation.Views.Project;
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

namespace Navigation.Views.Root
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageFlyout : ContentPage
    {
        public ListView ListView;

        public RootPageFlyout()
        {
            InitializeComponent();

            BindingContext = new RootPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class RootPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<RootPageFlyoutMenuItem> MenuItems { get; set; }

            public RootPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<RootPageFlyoutMenuItem>(new[]
                {
                    new RootPageFlyoutMenuItem { Id = 0, Title = "Students", TargetType=typeof(AllStudentsPage) },
                    new RootPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new RootPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
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