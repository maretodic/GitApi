using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using WebApiGit.Models;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Controllers
{
    public class PredmetController : ApiController
    {
        private readonly IPredmetRepository _predmetRepository;
        public PredmetController(IPredmetRepository predmetRepository)
        {
            this._predmetRepository = predmetRepository;
        }

        //GET: api/predmet
        [HttpGet]
        [Route("api/predmet")]
        public IHttpActionResult Get()
        {
            List<PredmetModel> list = _predmetRepository.Get();
            if (list.Count == 0)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        //GET: api/5/predmet
        [HttpGet]
        [Route("api/{id}/predmet")]
        public IHttpActionResult GetByID([FromUri]int id)
        {
            predmet predmetInDB = _predmetRepository.GetById(id);
            if(predmetInDB == null)
            {
                return NotFound();
            }
            else
            {
                PredmetModel predmetModel = new PredmetModel();
                Mapper.Map(predmetInDB, predmetModel);
                return Ok(predmetModel);
            }
        }

        //POST: api/predmet
        [HttpPost]
        [Route("api/predmet")]
        public IHttpActionResult Post([FromBody] PredmetModel predmetModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                _predmetRepository.Create(predmetModel);
                return Ok();
            }
        }

        //PUT: api/predmet
        [HttpPut]
        [Route("api/predmet")]
        public IHttpActionResult Put([FromBody] PredmetModel predmetModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            predmet predmetInDb = _predmetRepository.GetById(predmetModel.ID);

            if (predmetInDb == null)
            {
                return NotFound();
            }
            else
            {
                _predmetRepository.Edit(predmetInDb, predmetModel);
                return Ok();
            }
        }

        //DELETE: api/5/predmet
        [HttpDelete]
        [Route("api/{id}/predmet")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if(id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            predmet predmetInDb = _predmetRepository.GetById(id);

            if(predmetInDb == null)
            {
                return NotFound();
            }
            else
            {
                _predmetRepository.Delete(predmetInDb);
                return Ok();
            }
        }
    }
}
