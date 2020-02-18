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
        List<predmet> Get();
        void Create(predmet predmetInDb);
        void Edit(predmet predmetInDb);
        void Delete(predmet predmetInDb);
        predmet GetById(int id);
        void SaveChanges();
    }
}
