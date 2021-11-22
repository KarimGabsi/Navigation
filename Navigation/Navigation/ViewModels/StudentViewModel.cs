using Navigation.API;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Vives.DOMAIN;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public class StudentViewModel : BaseViewModel
    {
        private Student _Student;

        public ICommand GetByIdCommand { get; private set; }

        public Student Student
        {
            get => _Student; 
            set => SetValue(ref _Student, value); 
        }

        public StudentViewModel() : this(new Student() { Firstname="Tralaa" })
        {

        }

        public StudentViewModel(Student student)
        {
            Student = student;
            GetByIdCommand = new Command<int>(async x => await GetById(x));
        }

        private async Task GetById(int id)
        {
            try
            {
                using (APIService<IVivesStudent> service = new APIService<IVivesStudent>(GlobalVars.VivesAPI))
                {
                    var response = await service.myService.GetById(id);
                    Student = JsonConvert.DeserializeObject<APISingleResponse<Student>>(response).Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
