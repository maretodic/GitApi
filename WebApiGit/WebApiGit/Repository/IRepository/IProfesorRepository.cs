using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGit.Models;

namespace WebApiGit.Repository.IRepository
{
    public interface IProfesorRepository
    {
        List<profesors> Get();
        void Create(profesors profesorInDb);
        void Edit(profesors profesorInDb);
        void Delete(profesors profesorInDb);
        profesors GetById(int id);
        void SaveChanges();
    }
}
