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
    }
}
