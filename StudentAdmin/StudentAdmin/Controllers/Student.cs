using AutoMapper;
using ICSharpCode.Decompiler.CSharp.Resolver;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;

using StudentAdmin.Repository;

namespace StudentAdmin.Controllers
{
    [ApiController]
    public class Student : Controller
    {
        private readonly IStudentRepository studentRepository;
        //private readonly IMapper mapper;

        public Student(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
           // this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudent()
        {
            return  Ok(await studentRepository.Getstudent());
        }


        [HttpGet]

        [Route("[controller]/{Id:guid}")]
        public async Task<IActionResult> GetstudentById([FromRoute] Guid Id)
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

        [HttpPut]
        [Route("[controller]/{Id:guid}")]

        public async Task<IActionResult> Updatestudent([FromRoute] Guid Id, [FromBody] UpdateStudentRequest re)
        {
            // see if the student exisit
            if (await studentRepository.Exists(Id))
            {
                // update Details
                var updatedstudent = await studentRepository.UpdateStudent(Id, re);
                return Ok(updatedstudent);

            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete]
        [Route("[controller]/{Id:guid}")]

        public async Task<IActionResult> Deletestudent([FromRoute] Guid Id)
        {
            if (await studentRepository.Exists(Id))
            {
                var student = await studentRepository.DeleteStudent(Id);

                return Ok(student);

            }
            return NotFound();





        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudetAsync([FromBody] AddStudent re)
        {
            var newStudent = await studentRepository.AddNewStudent(re);
            return Ok(newStudent);



        }

    }
}





