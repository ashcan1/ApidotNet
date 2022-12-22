using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;
using StudentAdmin.Model;
using System.Threading.Tasks;

namespace StudentAdmin.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>>GetStudents();
        Task<Student> GetStudentById(Guid Id);
        Task<List<Gender>> GetGender();
        Task<bool>Exists(Guid Id);
        Task<Student> UpdateStudent(Guid Id, UpdateStudentRequest re);
        Task<Student> DeleteStudent(Guid Id);

        Task<AddStudent> AddNewStudent(Student addStudent);
        
    }
}

