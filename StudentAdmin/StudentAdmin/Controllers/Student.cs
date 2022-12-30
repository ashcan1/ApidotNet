using AutoMapper;
using ICSharpCode.Decompiler.CSharp.Resolver;
using Microsoft.AspNetCore.Mvc;
using StudentAdmin.DataModel;
using StudentAdmin.Interfaces;
using StudentAdmin.Repository;

namespace StudentAdmin.Controllers
{
    [ApiController]
    public class Student : Controller
    {
        private readonly IStudentRepository studentRepository;
        //private readonly IMapper mapper;
        private readonly IImageRepositiry imageRepository;  

        public Student(IStudentRepository studentRepository, IImageRepositiry imageRepositiry)
        {
            this.studentRepository = studentRepository;
            this.imageRepository = imageRepositiry;
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
        [Route("[controller]/add")]
   
        public async Task<IActionResult> AddStudetAsync([FromBody] AddStudent test)
        {
            var newStudent = await studentRepository.AddNewStudent(test);
            return Ok(newStudent);



        }

        [HttpPost]
        [Route("[controller]/{Id:guid}/upload-image")]

        public async Task<IActionResult> UploadFile([FromRoute] Guid Id,IFormFile profileImage)
        {
            //check student exist 
            if (await studentRepository.Exists(Id))
            {   
                // upload the image to local storage 
                var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
               var FileImagePath =  await imageRepository.Upload(profileImage, fileName);
                // update the profile image path in the database
               if(await studentRepository.UpdateProfilePicture(Id, FileImagePath))
                {
                    return Ok(FileImagePath);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, "error uploding image");




            }

            return NotFound();
            }
    }
}





