using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGit.Repository.IRepository;
using WebApiGit.Models;
using System.Data.Entity;

namespace WebApiGit.Repository
{
    public class PredmetRepository : BaseRepository, IPredmetRepository
    {
        public PredmetRepository(api_testEntities context) : base(context)
        {

        }

        public void Create(predmet predmetInDb)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(predmet predmetInDb)
        {
            throw new NotImplementedException();
        }

        public List<predmet> Get()
        {
            throw new NotImplementedException();
        }

        public predmet GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}