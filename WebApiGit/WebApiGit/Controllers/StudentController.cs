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

        //GET api/5/student
        [HttpGet]
        [Route("api/{id}/student")]
        public IHttpActionResult Get([FromUri] int id)
        {
            students studentInDB = _studentRepository.GetById(id);
            if(studentInDB == null)
            {
                return NotFound();
            }
            else
            {
                StudentModel studentDTO = _studentRepository.GetStudentDTO(studentInDB);
                return Ok(studentDTO);
            }
        }

        //POST api/student
        [HttpPost]
        [Route("api/student")]
        public IHttpActionResult Post([FromBody] StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Model State");
            }
            else
            {
                _studentRepository.Create(studentModel);
                return Ok();
            }
        }

        //PUT api/5/student
        [HttpPut]
        [Route("api/{id}/student")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Model State");
            }

            students studentInDb = _studentRepository.GetById(id);

            if(studentInDb == null)
            {
                return NotFound();
            }
            else
            {
                _studentRepository.Edit(studentInDb, studentModel);
                return Ok();
            }
        }

        //DELETE api/5/student
        [HttpDelete]
        [Route("api/{id}/student")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            students studentInDB = _studentRepository.GetById(id);
            if(studentInDB == null)
            {
                return NotFound();
            }
            else
            {
                _studentRepository.Delete(studentInDB);
                return Ok();
            }
        }
    }
}
