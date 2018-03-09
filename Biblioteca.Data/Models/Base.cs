using System;

namespace Biblioteca.Data.Models
{
    public abstract class Base
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; protected set; }
    }
}
