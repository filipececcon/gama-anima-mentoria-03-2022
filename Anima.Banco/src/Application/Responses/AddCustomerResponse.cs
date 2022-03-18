using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Responses
{
    public class AddCustomerResponse : Response
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
