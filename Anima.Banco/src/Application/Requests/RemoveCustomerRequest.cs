using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Requests
{
    public class RemoveCustomerRequest : Request
    {
        public Guid Id { get; set; }
    }
}
