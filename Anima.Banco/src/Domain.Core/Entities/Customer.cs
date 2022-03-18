using System;
namespace Anima.Banco.Domain.Core.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
