using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiGit.Repository
{
    public class BaseRepository
    {
        protected readonly api_testEntities context;
        public BaseRepository(api_testEntities context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}