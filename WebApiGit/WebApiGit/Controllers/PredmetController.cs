using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using System.Web.Http;
using WebApiGit.Models;
using WebApiGit.Repository.IRepository;
using WebApiGit.Persistence;

namespace WebApiGit.Controllers
{
    public class PredmetController : ApiController
    {
        private readonly UnitOfWork _unitOfWork;

        public PredmetController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //GET: api/predmet
        [HttpGet]
        [Route("api/predmet")]
        public IHttpActionResult Get()
        {
            List<predmet> listDb = _unitOfWork.predmetRepository.Get();
            List<PredmetModel> list = listDb.Select(Mapper.Map<predmet, PredmetModel>).ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            else return Ok(list);
        }

        //GET: api/5/predmet
        [HttpGet]
        [Route("api/{id}/predmet")]
        public IHttpActionResult GetByID([FromUri] int id)
        {
            predmet predmetInDB = _unitOfWork.predmetRepository.FindSingleBy(p => p.id == id);
            if (predmetInDB == null)
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
                return BadRequest(ModelState);
            }
            else
            {
                predmet predmet = Mapper.Map<PredmetModel, predmet>(predmetModel);
                _unitOfWork.predmetRepository.Create(predmet);
                _unitOfWork.SaveChanges();
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
                return BadRequest(ModelState);
            }

            predmet predmetInDb = _unitOfWork.predmetRepository.FindSingleBy(p => p.id == id);

            if (predmetInDb == null)
            {
                return NotFound();
            }
            else
            {
                Mapper.Map(predmetModel, predmetInDb);
                _unitOfWork.predmetRepository.Edit(predmetInDb);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }

        //DELETE: api/5/predmet
        [HttpDelete]
        [Route("api/{id}/predmet")]
        public IHttpActionResult Delete([FromUri] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }

            predmet predmetInDb = _unitOfWork.predmetRepository.FindSingleBy(p => p.id == id);

            if (predmetInDb == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.predmetRepository.Delete(predmetInDb);
                _unitOfWork.SaveChanges();
                return Ok();
            }
        }
    }
}