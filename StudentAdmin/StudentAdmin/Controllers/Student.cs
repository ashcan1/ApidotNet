using Microsoft.AspNetCore.Mvc;
using StudentAdmin.Model;
using StudentAdmin.Repository;

namespace StudentAdmin.Controllers
{
    [ApiController]
    public class Student : Controller
    {
        private readonly IStudentRepository studentRepository;

        public Student(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudent()
        {
            return Ok(await studentRepository.GetStudents());
        }


        [HttpGet]

        [Route("[controller]/{Id:guid}")]
        public async Task<IActionResult> GetStudentsById([FromRoute]Guid Id)
        {
            // fetch student details
        var student = await studentRepository.GetStudentById(Id);

            // Return student
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }



    }
}
