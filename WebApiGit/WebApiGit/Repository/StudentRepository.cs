using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(api_testEntities context) : base(context)
        {

        }

        public void Create(students studentInDb)
        {
            context.students.Add(studentInDb);
        }

        public void Delete(students studentInDb)
        {
            context.students.Remove(studentInDb);
        }

        public void Edit(students studentInDb)
        {
            context.Entry(studentInDb).State = EntityState.Modified;
        }

        public List<students> Get()
        {
            return context.students.ToList();
        }

        public students GetById(int id)
        {
            return context.students.SingleOrDefault(s => s.id == id);
        }
    }
}