using StudentAdmin.Model;

namespace StudentAdmin.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>>GetStudents();
        Task<Student> GetStudentById(Guid Id);
      
    }
}
