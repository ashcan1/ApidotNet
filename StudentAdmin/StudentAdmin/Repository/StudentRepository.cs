using Microsoft.EntityFrameworkCore;
using StudentAdmin.DataModel;
using StudentAdmin.Model;
using System.Reflection.Metadata.Ecma335;

namespace StudentAdmin.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;
        public StudentRepository(StudentAdminContext context)
        {
            this._context = context;

        }

        //Students and navigition properties  


        public async Task<List<Students>> GetStudents()
        {

            return await _context.Student.Include(nameof(Gender))
                .Include(nameof(Address)).ToListAsync();
        }

        public async Task<Students> GetStudentById(Guid Id)
        {
            return await _context.Student
                  .Include(nameof(Gender))
                  .Include(nameof(Address))
                  .FirstOrDefaultAsync(x => x.Id == Id);
        }



        public async Task<List<Gender>> GetGender()
        {
            return await _context.Gender.ToListAsync();

        }

        public async Task<bool> Exists(Guid Id)
        {
            return await _context.Student.AnyAsync(x => x.Id == Id);
        }




        public async Task<Students>UpdateStudent(Guid Id, UpdateStudentRequest re)
        {
           var existingStudents =  await GetStudentById(Id);

            if (existingStudents != null)
            {
                existingStudents.FirstName = re.FirstName;
                existingStudents.LastName = re.LastName;
                //existingStudents.Address.PhysicalAddress = re.Address.PhysicalAddress;
                //existingStudents.Address.PostalAddress = re.Address.PostalAddress;
                existingStudents.DateOfBirth = re.DateOfBirth;
                existingStudents.Email = re.Email;
                existingStudents.Mobile = re.Mobile;

                await _context.SaveChangesAsync();

                return existingStudents;
                
                


            }

            return null;

        }




        public async Task<Students>DeleteStudent(Guid Id)
        {

            var students  = await  GetStudentById(Id);
            if (students  != null)
            {
               _context.Student.Remove(students);
                _context.SaveChanges();
            }

            return null;

       






        }

        // adding student logic 



        //public async Task<Students> AddNewStudent(AddStudent request)
        //{
        //    // create student
        //    var test = new Students();
        //    {
        //        test.Id = Guid.NewGuid();
        //        test.FirstName = request.FirstName;
        //        test.LastName = request.LastName;
        //        test.DateOfBirth = request.DateOfBirth;
        //        test.Email = request.Email;
        //        test.Mobile = request.Mobile;
        //        test.Address = request.Address;



        //    }
     



        
   
        //    await _context.SaveChangesAsync();



        //    return test;
 



        //}

    }
}
    