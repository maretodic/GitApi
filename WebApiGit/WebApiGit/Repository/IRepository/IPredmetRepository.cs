using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGit.Models;

namespace WebApiGit.Repository.IRepository
{
    public interface IPredmetRepository
    {
        List<PredmetModel> Get();
        void Create(PredmetModel predmetModel);
        void Edit(predmet predmetInDb, PredmetModel predmetModel);
        void Delete(predmet predmetInDb);
        predmet GetById(int id);
    }
}
