using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGit.Models;
using AutoMapper;
using WebApiGit.Repository.IRepository;
using WebApiGit.Persistence;

namespace WebApiGit.Controllers
{
    public class StudentController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public StudentController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //GET api/student
        [HttpGet]
        [Route("api/student")]
        public IHttpActionResult Get()
        {
            List<students> listDb = _unitOfWork.studentRepository.Get();
            List<StudentModel> studentList = listDb.Select(Mapper.Map<students, StudentModel>).ToList();
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
            students studentInDB = _unitOfWork.studentRepository.FindSingleBy(s => s.id == id);
            if (studentInDB == null)
            {
                return NotFound();
            }
            else
            {
                StudentModel studentDTO = Mapper.Map<students, StudentModel>(studentInDB);
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
                return BadRequest(ModelState);
            }
            else
            {
                students student = Mapper.Map<StudentModel, students>(studentModel);
                _unitOfWork.studentRepository.Create(student);
                _unitOfWork.SaveChanges();
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
                return BadRequest(ModelState);
            }

            students studentInDb = _unitOfWork.studentRepository.FindSingleBy(s => s.id == id);

            if (studentInDb == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(studentModel, studentInDb);
                _unitOfWork.studentRepository.Edit(studentInDb);
                _unitOfWork.SaveChanges();
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

            students studentInDB = _unitOfWork.studentRepository.FindSingleBy(s => s.id == id);
            if (studentInDB == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.studentRepository.Delete(studentInDB);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }
    }
}