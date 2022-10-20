using Microsoft.AspNetCore.Mvc;
using StudentAdmin.Repository;

namespace StudentAdmin.Controllers
{
    [ApiController]
    public class Student : Controller
    {
        private readonly IstudentRepository studentRepository;

        public Student(IstudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAllStudent()
        {
            return Ok (studentRepository.GetStudents());
        }
    }
}
