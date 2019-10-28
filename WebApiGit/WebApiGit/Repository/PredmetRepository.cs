using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGit.Repository.IRepository;
using WebApiGit.Models;
using AutoMapper;

namespace WebApiGit.Repository
{
    public class PredmetRepository : BaseRepository, IPredmetRepository
    {
        public PredmetRepository(api_testEntities context) : base(context)
        {

        }
        public void Create(PredmetModel predmetModel)
        {
            predmet predmetForDB = new predmet();
            Mapper.Map(predmetModel, predmetForDB);
            context.predmet.Add(predmetForDB);
            base.SaveChanges();
        }

        public void Delete(predmet predmetInDb)
        {
            context.predmet.Remove(predmetInDb);
            base.SaveChanges();
        }

        public void Edit(predmet predmetInDb, PredmetModel predmetModel)
        {
            Mapper.Map(predmetModel, predmetInDb);
            base.SaveChanges();
        }

        public List<PredmetModel> Get()
        {
            return context.predmet.ToList().Select(Mapper.Map<predmet, PredmetModel>).ToList();
        }

        public predmet GetById(int id)
        {
            return context.predmet.FirstOrDefault(x => x.id == id);
        }

        public PredmetModel GetPredmetDTO(predmet predmetInDb)
        {
            PredmetModel predmetDTO = new PredmetModel();
            return Mapper.Map(predmetInDb, predmetDTO);
        }
    }

}