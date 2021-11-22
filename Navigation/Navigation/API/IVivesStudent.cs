using Refit;
using System.Threading.Tasks;
using Vives.DOMAIN;

namespace Navigation.API
{
    public interface IVivesStudent
    {
        [Get("/student/getbyid?id={id}")]
        Task<string> GetById(int id);

        [Get("/student/get?skip={skip}&take={take}")]
        Task<string> Get(int skip, int take);

        [Post("/student/create")]
        Task<string> Create([Body]Student student);

        [Post("/student/update")]
        Task<string> Update([Body] Student student);

        [Post("/student/delete")]
        Task<string> Delete([Body] Student student);
    }
}
