﻿using System;
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
    }
}
