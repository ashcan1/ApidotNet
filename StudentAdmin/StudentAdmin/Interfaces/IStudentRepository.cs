using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;
using System.Threading.Tasks;

namespace StudentAdmin.Repository
{
    public interface IStudentRepository
    {
        Task<List<student>>Getstudent();
        Task<student> GetStudentById(Guid Id);
        Task<List<Gender>> GetGender();
        Task<bool>Exists(Guid Id);
        Task<student> UpdateStudent(Guid Id, UpdateStudentRequest re);
        Task<student> DeleteStudent(Guid Id);


        Task<student> AddNewStudent(AddStudent request);


    }
}

