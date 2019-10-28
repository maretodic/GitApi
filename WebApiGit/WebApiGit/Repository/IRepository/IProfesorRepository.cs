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
        List<ProfesorModel> Get();
        profesors GetById(int id);
        ProfesorModel GetProfesorDTO(profesors profesorInDb);
        void Create(ProfesorModel profesorDTO);
        void Edit(profesors profesorInDb, ProfesorModel profesorDTO);
        void Delete(profesors profesorInDb);
    }
}
