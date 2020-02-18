using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiGit.Models;
using AutoMapper;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Controllers
{
    public class ProfesorController : ApiController
    {
        private readonly IProfesorRepository _profesorRepository;
        public ProfesorController(IProfesorRepository profesorRepository)
        {
            this._profesorRepository = profesorRepository;
        }

        //GET: api/profesor
        [HttpGet]
        [Route("api/profesor")]
        public IHttpActionResult Get()
        {
            List<ProfesorModel> ListDTO = _profesorRepository.Get().Select(Mapper.Map<profesors, ProfesorModel>).ToList();
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
            profesors profesorInDB = _profesorRepository.GetById(id);
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
        public IHttpActionResult Post([FromBody]ProfesorModel profesorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                profesors profesor = Mapper.Map<ProfesorModel, profesors>(profesorDTO);
                _profesorRepository.Create(profesor);
                _profesorRepository.SaveChanges();
                return Ok();
            }
        }

        //PUT: api/5/profesor
        [HttpPut]
        [Route("api/{id}/profesor")]
        public IHttpActionResult Put([FromUri]int id, [FromBody] ProfesorModel profesorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            profesors profesorInDB = _profesorRepository.GetById(id);
            if(profesorInDB == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(profesorDTO, profesorInDB);
                _profesorRepository.Edit(profesorInDB);
                _profesorRepository.SaveChanges();
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

            profesors profesorInDb = _profesorRepository.GetById(id);
            if (profesorInDb == null)
            {
                return NotFound();
            }
            else
            {
                _profesorRepository.Delete(profesorInDb);
                return Ok();
            }
        }
    }
}
