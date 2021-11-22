using Navigation.API;
using Navigation.AppService;
using Navigation.Views.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Vives.DOMAIN;
using Xamarin.Forms;

namespace Navigation.ViewModels
{
    public struct GetParam
    {
        public int skip;
        public int take;
    }
    public class AllStudentViewModel : BaseViewModel
    {
        private PageService pageService = new PageService();
        public ICommand GetCommand { get; private set; }
        private ObservableCollection<Student> _Students;

        public ObservableCollection<Student> Students
        {
            get => _Students;
            set => SetValue(ref _Students, value);
        }
        public AllStudentViewModel() : this(new List<Student>() { new Student() { Firstname="John" } })
        {

        }
        public AllStudentViewModel(List<Student> students)
        {
            Students = new ObservableCollection<Student>(students);
            GetCommand = new Command<GetParam>(async x => await Get(x));
        }

        private async Task Get(GetParam x)
        {
            try
            {
                using (APIService<IVivesStudent> service = new APIService<IVivesStudent>(GlobalVars.VivesAPI))
                {
                    string response = await service.myService.Get(skip: x.skip, take: x.take);
                    IEnumerable<Student> students = JsonConvert.DeserializeObject<APIMultiResponse<Student>>(response).Value;
                    Students = new ObservableCollection<Student>();
                    foreach (Student student in students)
                    {
                        Students.Add(student);
                    }
                }

            }
            catch (Exception ex)
            {
                await pageService.PushAync(new ErrorPage(ex));
            }
        }
    }
}
