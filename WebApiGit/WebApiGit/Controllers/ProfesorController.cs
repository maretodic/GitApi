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
            List<ProfesorModel> ListDTO = _profesorRepository.Get();
            if (ListDTO.Count == 0)
            {
                return NotFound();
            }
            else return Ok(ListDTO);
        }
    }
}
