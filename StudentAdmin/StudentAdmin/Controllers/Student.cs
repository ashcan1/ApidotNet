using AutoMapper;
using ICSharpCode.Decompiler.CSharp.Resolver;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;
using StudentAdmin.Model;
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
            return Ok(studentRepository.GetStudents());
        }


        [HttpGet]

        [Route("[controller]/{Id:guid}")]
        public async Task<IActionResult> GetStudentsById([FromRoute] Guid Id)
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

        public async Task<IActionResult> UpdateStudents([FromRoute] Guid Id, [FromBody] UpdateStudentRequest re)
        {
            // see if the student exisit
            if (await studentRepository.Exists(Id))
            {
                // update Details
                var updatedStudents = await studentRepository.UpdateStudent(Id, re);
                return Ok(updatedStudents);

            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete]
        [Route("[controller]/{Id:guid}")]

        public async Task<IActionResult> DeleteStudents([FromRoute] Guid Id)
        {
            if (await studentRepository.Exists(Id))
            {
                var students = await studentRepository.DeleteStudent(Id);

                return Ok(students);

            }
            return NotFound();





        }

        //[HttpPost]
        //[Route("[controller]/Add")]
        //public async Task<IActionResult> AddStudetAsync([FromBody] AddStudent re)
        //{
        //    var newStudent = await studentRepository.AddNewStudent(re);
        //    return Ok(newStudent);



        //}

    }
}





