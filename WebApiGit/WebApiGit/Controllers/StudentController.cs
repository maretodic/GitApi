using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGit.Models;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        //GET api/student
        [HttpGet]
        [Route("api/student")]
        public IHttpActionResult Get()
        {
            List<StudentModel> studentList = _studentRepository.Get();
            if (studentList.Count == 0)
            {
                return NotFound();
            }
            else return Ok(studentList);
        }
    }
}
