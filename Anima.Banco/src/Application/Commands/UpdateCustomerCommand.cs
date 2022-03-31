using System;
using System.Linq;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Requests;
using Anima.Banco.Application.Responses;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;

namespace Anima.Banco.Application.Commands
{
    public class UpdateCustomerCommand : Command<UpdateCustomerRequest, UpdateCustomerResponse>
    {
        public UpdateCustomerCommand(IWriteRepository repository) : base(repository)
        {
        }

        protected override UpdateCustomerResponse Changes(UpdateCustomerRequest request)
        {
            var customer = _repository.AsQueryable<Customer>().SingleOrDefault(x => x.Id == request.GetId());

            customer.Name = request.Name;
            customer.Email = request.Email;

            

            return new UpdateCustomerResponse();
        }
    }
}
