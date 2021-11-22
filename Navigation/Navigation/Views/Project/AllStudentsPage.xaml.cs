using Navigation.AppService;
using Navigation.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Vives.DOMAIN;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Views.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllStudentsPage : ContentPage
    {
        private PageService pageService = new PageService();
        private GetParam st;
        public AllStudentsPage()
        {
            InitializeComponent();
            st = new GetParam() { skip = 0, take = 20 };
            GetStudents();
        }

        private void GetStudents()
        {
            (BindingContext as AllStudentViewModel).GetCommand.Execute(st);
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await pageService.PushAync(new StudentPage(e.Item as Student));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void PrevStudents_Clicked(object sender, EventArgs e)
        {
            st.skip -= st.take;
            st.skip = st.skip < 0 ? 0 : st.skip;
            GetStudents();
        }

        private void NextStudents_Clicked(object sender, EventArgs e)
        {
            st.skip += st.take;
            GetStudents();
        }

        private void AddStudent_Clicked(object sender, EventArgs e)
        {

        }
    }
}
