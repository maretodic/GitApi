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
        List<StudentModel> Get();
        void Create(StudentModel studentModel);
        void Edit(students studentInDb, StudentModel studentModel);
        void Delete(students studentInDB);
        students GetById(int id);
        StudentModel GetStudentDTO(students studentInDb);
    }
}
