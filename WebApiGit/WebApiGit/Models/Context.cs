using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiGit.Models
{
    public class Context
    {
        public DbSet<ProfesorModel> profesors { get; set; }
        public DbSet<PredmetModel> predmets { get; set; }
        public DbSet<StudentModel> students { get; set; }
    }
}