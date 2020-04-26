using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiGit.Repository;

namespace WebApiGit.Persistence
{
    public class UnitOfWork : IDisposable
    {
        private api_testEntities _context = new api_testEntities();
        private GenericRepository<profesors> _profesorRepository;
        private GenericRepository<students> _studentRepository;
        private GenericRepository<predmet> _predmetRepository;

        public GenericRepository<profesors> profesorRepository
        {
            get
            {
                if (_profesorRepository == null)
                {
                    _profesorRepository = new GenericRepository<profesors>(_context);
                }
                return _profesorRepository;
            }
        }

        public GenericRepository<students> studentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new GenericRepository<students>(_context);
                }
                return _studentRepository;
            }
        }

        public GenericRepository<predmet> predmetRepository
        {
            get
            {
                if (_predmetRepository == null)
                {
                    _predmetRepository = new GenericRepository<predmet>(_context);
                }
                return _predmetRepository;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}