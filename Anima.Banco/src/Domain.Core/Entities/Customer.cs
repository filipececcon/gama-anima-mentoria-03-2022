using System;
using Anima.Banco.Domain.Shared.Entities;

namespace Anima.Banco.Domain.Core.Entities
{
    public class Customer : Entity
    {
        private Customer() { }

        public Customer(string name, string email) : base(Guid.NewGuid())
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
