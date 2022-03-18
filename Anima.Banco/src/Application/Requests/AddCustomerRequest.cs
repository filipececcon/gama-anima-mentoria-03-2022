using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Requests
{
    public class AddCustomerRequest : Request
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
