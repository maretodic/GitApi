using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGit.Models;

namespace WebApiGit.Repository.IRepository
{
    public interface IStudentRepository
    {
        List<students> Get();
        void Create(students studentInDb);
        void Edit(students studentInDb);
        void Delete(int id);
        students GetById(int id);
        void SaveChanges();
    }
}
