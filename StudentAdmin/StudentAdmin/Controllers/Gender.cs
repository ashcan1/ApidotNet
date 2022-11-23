using Microsoft.AspNetCore.Mvc;
using StudentAdmin.Repository;
using System.Reflection.Metadata.Ecma335;

namespace StudentAdmin.Controllers
{

    
    public class Gender : Controller
    {
        private readonly IStudentRepository studentRepository;

        public Gender(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }


        [HttpGet]

        [Route("[controller]")]
        public async Task <IActionResult> getAllGender()
        {

            return Ok(await studentRepository.GetGender());
        }


    }
}
