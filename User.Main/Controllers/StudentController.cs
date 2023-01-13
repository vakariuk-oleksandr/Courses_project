using Main_Project.BL.DTO;
using Main_Project.Data;
using Main_Project.Interfaces;
using Main_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Main_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentServices studentServices;
        public StudentController(IStudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentDTO>> GetS()
        {
            return await studentServices.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult> CreateS(StudentDTO student)
        {
            await studentServices.AddStudent(student);
            return NoContent(); //NoContent - status 204 (We havn't any data)
        }

        [HttpGet("{StudentID}")]
        public async Task<ActionResult<User>> GetS(string StudentID)
        {
            return Ok(await studentServices.GetStudentById(StudentID));
        }

        [HttpDelete("{StudentID}")]
        public async Task<ActionResult> DelS(User StudentID)
        {
            await studentServices.DeleteStudent(StudentID);
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<string> Login([FromBody] UserLoginDTO userLogin)
        {
            return await studentServices.Login(userLogin);
        }

        [HttpPost("GetByToken")]
        public async Task<StudentDTO> GetUserByAccessToken([FromBody] string token)
        {
            return await studentServices.GetStudentByAccessToken(token);
        }

        [HttpPost("Register")]
        public async Task<bool> RegisterUser([FromBody] RegisterDTO studRegister)
        {
            return await studentServices.Register(studRegister);
        }
    }
}
