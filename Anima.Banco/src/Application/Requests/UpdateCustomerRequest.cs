using System;
using Anima.Banco.Application.Common;

namespace Anima.Banco.Application.Requests
{
    public class UpdateCustomerRequest : Request
    {      
        public string Name { get; set; }

        public string Email { get; set; }

        private Guid Id { get; set; }

        public Guid GetId()
        {
            return Id;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
