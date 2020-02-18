using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiGit.Models;
using System.Data.Entity;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Repository
{
    public class ProfesorRepository : BaseRepository, IProfesorRepository
    {
        public ProfesorRepository(api_testEntities context) : base(context)
        {

        }

        public void Create(profesors profesorInDb)
        {
            context.profesors.Add(profesorInDb);
        }

        public void Delete(profesors profesorInDb)
        {
            context.profesors.Remove(profesorInDb);
        }

        public void Edit(profesors profesorInDb)
        {
            context.Entry(profesorInDb).State = EntityState.Modified;
        }

        public List<profesors> Get()
        {
            return context.profesors.ToList();
        }

        public profesors GetById(int id)
        {
            return context.profesors.Single(p => p.id == id);
        }
    }
}