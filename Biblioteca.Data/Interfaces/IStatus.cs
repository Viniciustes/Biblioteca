using Biblioteca.Data.Models;
using System;
using System.Collections.Generic;

namespace Biblioteca.Data.Interfaces
{
    public interface IStatus
    {
        void Add(Status status);
        void Add(List<Status> status);
        Status GetById(Guid id);
    }
}
