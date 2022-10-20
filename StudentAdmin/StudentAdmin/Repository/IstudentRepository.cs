using StudentAdmin.Model;

namespace StudentAdmin.Repository
{
    public interface IstudentRepository
    {
        List<Student> GetStudents();
    }
}
