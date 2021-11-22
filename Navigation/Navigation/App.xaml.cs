using Navigation.Views.Project;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StudentPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
