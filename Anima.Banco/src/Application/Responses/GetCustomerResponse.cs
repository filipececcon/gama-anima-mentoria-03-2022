using System;
using System.Collections.Generic;
using System.Linq;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Responses
{
    public class GetCustomerResponse : Response
    {
        public IQueryable<GetCustomerResponseItem> Data { get; set; }
    }

    public class GetCustomerResponseItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
