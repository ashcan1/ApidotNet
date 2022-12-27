using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;
using StudentAdmin.Model;
using System.Threading.Tasks;

namespace StudentAdmin.Repository
{
    public interface IStudentRepository
    {
        Task<List<Students>>GetStudents();
        Task<Students> GetStudentById(Guid Id);
        Task<List<Gender>> GetGender();
        Task<bool>Exists(Guid Id);
        Task<Students> UpdateStudent(Guid Id, UpdateStudentRequest re);
        Task<Students> DeleteStudent(Guid Id);


      //  Task<Students> AddNewStudent(AddStudent request);


    }
}

