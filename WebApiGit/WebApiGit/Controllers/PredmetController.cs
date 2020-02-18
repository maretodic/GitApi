using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
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
            List<PredmetModel> list = _predmetRepository.Get().Select(Mapper.Map<predmet, PredmetModel>).ToList();
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
                PredmetModel predmetModel = Mapper.Map<predmet, PredmetModel>(predmetInDB);
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
                predmet predmet = Mapper.Map<PredmetModel, predmet>(predmetModel);
                _predmetRepository.Create(predmet);
                _predmetRepository.SaveChanges();
                return Ok();
            }
        }

        //PUT: api/predmet
        [HttpPut]
        [Route("api/predmet")]
        public IHttpActionResult Put([FromUri] int id, [FromBody] PredmetModel predmetModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }

            predmet predmetInDb = _predmetRepository.GetById(id);

            if (predmetInDb == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(predmetModel, predmetInDb);
                _predmetRepository.Edit(predmetInDb);
                _predmetRepository.SaveChanges();
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
                _predmetRepository.Delete(id);
                _predmetRepository.SaveChanges();
                return Ok();
            }
        }
    }
}
