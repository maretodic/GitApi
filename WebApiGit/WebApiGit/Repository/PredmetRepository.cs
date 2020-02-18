﻿using System;
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
            context.predmet.Add(predmetInDb);
        }

        public void Delete(int id)
        {
            predmet predmet = this.GetById(id);
            context.predmet.Remove(predmet);
        }

        public void Edit(predmet predmetInDb)
        {
            context.Entry(predmetInDb).State = EntityState.Modified;
        }

        public List<predmet> Get()
        {
            return context.predmet.ToList();
        }

        public predmet GetById(int id)
        {
            return context.predmet.Single(p => p.id == id);
        }
    }
}