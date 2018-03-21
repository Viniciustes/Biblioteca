using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Data.Context;
using Biblioteca.Data.Interfaces;
using Biblioteca.Data.Models;

namespace Biblioteca.Services.Services
{
    public class StatusService: BaseService, IStatus
    {
        public StatusService(DbContextBiblioteca dbContextBiblioteca)
        {
            _db = dbContextBiblioteca;
        }

        public void Add(Status status)
        {
            _db.Add(status);
            _db.SaveChanges();
        }

        public void Add(List<Status> status)
        {
            _db.AddRange(status);
            _db.SaveChanges();
        }

        public Status GetById(Guid id)
        {
            return _db.Status.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
