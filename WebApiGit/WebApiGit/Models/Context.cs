using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiGit.Models
{
    public class Context : DbContext
    {
        public DbSet<ProfesorModel> profesorModels { get; set; }
        public DbSet<PredmetModel> predmetModels { get; set; }
        public DbSet<StudentModel> studentModels { get; set; }
    }
}