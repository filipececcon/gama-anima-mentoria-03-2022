using System.Linq;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Requests;
using Anima.Banco.Application.Responses;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;

namespace Anima.Banco.Application.Commands
{
    // os comandos são instruçoes que alteram o estado do servidor
    public class AddCustomerCommand : Command<AddCustomerRequest, AddCustomerResponse>
    {
        public AddCustomerCommand(IWriteRepository repository) : base(repository)
        {
        }

        //todo metodo handle tem que caracterizar um transação
        protected override AddCustomerResponse Changes(AddCustomerRequest request)
        {
            var result = _repository.AsQueryable<Customer>().Where(x => x.Email == request.Email);

            var response = new AddCustomerResponse();

            if (result.Any()) response.AddError("Email ja existe");

            if (response.IsSuccess)
            {

                var customer = new Customer(request.Name, request.Email);

                _repository.Add(customer);

                response.Id = customer.Id;
                response.CreatedAt = customer.CreatedAt;
            }

            return response;
        }
    }
}
