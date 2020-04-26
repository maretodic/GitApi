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
    public class ProfesorController : ApiController
    {
        private UnitOfWork _unitOfWork;

        public ProfesorController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //GET: api/profesor
        [HttpGet]
        [Route("api/profesor")]
        public IHttpActionResult Get()
        {
            List<profesors> listDb = _unitOfWork.profesorRepository.Get();
            List<ProfesorModel> ListDTO = listDb.Select(Mapper.Map<profesors, ProfesorModel>).ToList();
            if (ListDTO.Count == 0)
            {
                return NotFound();
            }
            else return Ok(ListDTO);
        }

        //GET: api/5/profesor
        [HttpGet]
        [Route("api/{id}/profesor")]
        public IHttpActionResult Get(int id)
        {
            profesors profesorInDB = _unitOfWork.profesorRepository.GetById(id);
            if (profesorInDB == null)
            {
                return NotFound();
            }
            else
            {
                ProfesorModel profesorDTO = Mapper.Map<profesors, ProfesorModel>(profesorInDB);
                return Ok(profesorDTO);
            }
        }

        //POST: api/profesor
        [HttpPost]
        [Route("api/{id}/profesor")]
        public IHttpActionResult Post([FromBody] ProfesorModel profesorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                profesors profesor = Mapper.Map<ProfesorModel, profesors>(profesorDTO);
                _unitOfWork.profesorRepository.Create(profesor);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }

        //PUT: api/5/profesor
        [HttpPut]
        [Route("api/{id}/profesor")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] ProfesorModel profesorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            profesors profesorInDB = _unitOfWork.profesorRepository.GetById(id);
            if (profesorInDB == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(profesorDTO, profesorInDB);
                _unitOfWork.profesorRepository.Edit(profesorInDB);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }

        //DELETE: api/5/profesor
        [HttpDelete]
        [Route("api/{id}/profesor")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id");
            }

            profesors profesorInDb = _unitOfWork.profesorRepository.GetById(id);
            if (profesorInDb == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.profesorRepository.Delete(profesorInDb);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }
    }
}