using StudentAdmin.DataModel;
using StudentAdmin.Model;

namespace StudentAdmin.Repository
{
    public class SqlStudentRepository: IstudentRepository
    {
        private readonly StudentAdminContext _context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            this._context = context;

        }

          List<Student> IstudentRepository.GetStudents()
        {
           return _context.Student.ToList();
        }
    }
}
    