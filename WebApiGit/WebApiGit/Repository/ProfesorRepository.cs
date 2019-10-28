using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiGit.Models;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Repository
{
    public class ProfesorRepository : BaseRepository, IProfesorRepository
    {
        public ProfesorRepository(api_testEntities context) : base(context)
        {

        }

        public void Create(ProfesorModel profesorDTO)
        {
            profesors profesorInDb = new profesors();
            Mapper.Map(profesorDTO, profesorInDb);
            context.profesors.Add(profesorInDb);
            SaveChanges();
        }

        public void Delete(profesors profesorInDb)
        {
            context.profesors.Remove(profesorInDb);
            SaveChanges();
        }

        public void Edit(profesors profesorInDb, ProfesorModel profesorDTO)
        {
            Mapper.Map(profesorDTO, profesorInDb);
            SaveChanges();
        }

        public List<ProfesorModel> Get()
        {
            return context.profesors.ToList().Select(Mapper.Map<profesors, ProfesorModel>).ToList();
        }

        public profesors GetById(int id)
        {
            return context.profesors.FirstOrDefault(x => x.id == id);
        }

        public ProfesorModel GetProfesorDTO(profesors profesorInDb)
        {
            ProfesorModel profesorDTO = new ProfesorModel();
            return Mapper.Map(profesorInDb, profesorDTO);
        }
    }
}