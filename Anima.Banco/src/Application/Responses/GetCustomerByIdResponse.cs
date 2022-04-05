using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Responses
{
    public class GetCustomerByIdResponse : Response
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
