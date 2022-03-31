using System;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Responses;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;

namespace Anima.Banco.Application.Requests
{
    public class RemoveCustomerCommand : Command<RemoveCustomerRequest, RemoveCustomerResponse>
    {
        public RemoveCustomerCommand(IWriteRepository repository) : base(repository)
        {
        }

        protected override RemoveCustomerResponse Changes(RemoveCustomerRequest request)
        {
            _repository.Remove<Customer>(request.Id);

            return new RemoveCustomerResponse();
        }
    }
}
