using Navigation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vives.DOMAIN;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation.Views.Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentPage : ContentPage
    {
        public StudentPage(Student student)
        {
            InitializeComponent();
            BindingContext = new StudentViewModel(student);
            //(BindingContext as StudentViewModel).GetByIdCommand.Execute(2);
        }

    }
}