using Microsoft.EntityFrameworkCore;
using StudentAdmin.DataModel;



namespace StudentAdmin.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext _context;
        public StudentRepository(StudentAdminContext context)
        {
            this._context = context;

        }

        //student and navigition properties  


        public async Task<List<student>> Getstudent()
        {

            return await _context.Student.Include(nameof(Gender))
                .Include(nameof(Address)).ToListAsync();
        }

        public async Task<student> GetStudentById(Guid Id)
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




        public async Task<student>UpdateStudent(Guid Id, UpdateStudentRequest re)
        {
           var existingstudent =  await GetStudentById(Id);

            if (existingstudent != null)
            {
                existingstudent.FirstName = re.FirstName;
                existingstudent.LastName = re.LastName;
                //existingstudent.Address.PhysicalAddress = re.Address.PhysicalAddress;
                //existingstudent.Address.PostalAddress = re.Address.PostalAddress;
                existingstudent.DateOfBirth = re.DateOfBirth;
                existingstudent.Email = re.Email;
                existingstudent.Mobile = re.Mobile;

                await _context.SaveChangesAsync();

                return existingstudent;
                
                


            }

            return null;

        }




        public async Task<student>DeleteStudent(Guid Id)
        {

            var student  = await  GetStudentById(Id);
            if (student  != null)
            {
               _context.Student.Remove(student);
                _context.SaveChanges();
            }

            return null;

       






        }

        // adding student logic 



        public async Task<student> AddNewStudent(AddStudent request)
        {
            // create student
            var mappingStudent = new student();
            {
                mappingStudent.Id = Guid.NewGuid();
                mappingStudent.FirstName = request.FirstName;
                mappingStudent.LastName = request.LastName;
                mappingStudent.DateOfBirth = request.DateOfBirth;
                mappingStudent.Email = request.Email;
                mappingStudent.Mobile = request.Mobile;
                mappingStudent.GenderId = request.GenderId;
                mappingStudent.Address = request.Address;

            }

            var newStudent = await _context.Student.AddAsync(mappingStudent);
            await _context.SaveChangesAsync();
            return newStudent.Entity;

        }

        public async Task<bool> UpdateProfilePicture(Guid Id, string profileImageUrl)
        {
            var student = await GetStudentById(Id);
            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;  
                await _context.SaveChangesAsync();
                return true;
                
             
            }
            else
            {
                return false;
            }
        }
    }
}
    