using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Requests
{
    public class GetCustomerByIdRequest : Request
    {
        public Guid Id { get; set; }
    }
}
