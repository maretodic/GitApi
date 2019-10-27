using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using WebApiGit.Models;
using WebApiGit.Repository.IRepository;

namespace WebApiGit.Repository
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        public StudentRepository(api_testEntities context) : base(context)
        {

        }

        public void Create(StudentModel studentModel)
        {
            students studentForDB = new students();
            Mapper.Map(studentModel, studentForDB);
            context.students.Add(studentForDB);
            SaveChanges();
        }

        public void Delete(students studentInDB)
        {
            context.students.Remove(studentInDB);
            SaveChanges();
        }

        public void Edit(students studentInDb, StudentModel studentModel)
        {
            Mapper.Map(studentModel, studentInDb);
            SaveChanges();
        }

        public List<StudentModel> Get()
        {
            return context.students.ToList().Select(Mapper.Map<students, StudentModel>).ToList();
        }

        public students GetById(int id)
        {
            return context.students.FirstOrDefault(x => x.id == id);
        }

        public StudentModel GetStudentDTO(students studentInDb)
        {
            StudentModel studentModel = new StudentModel();
            return Mapper.Map(studentInDb, studentModel);
        }
    }
}